using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using Equinor.Lighthouse.Api.Command;
using Equinor.Lighthouse.Api.Query;
using Equinor.Lighthouse.Api.WebApi.DIModules;
using Equinor.Lighthouse.Api.WebApi.Middleware;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Equinor.Lighthouse.Api.WebApi;

public class Startup
{
    private const string AllowAllOriginsCorsPolicy = "AllowAllOrigins";
    private readonly IWebHostEnvironment _environment;

    public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
        Configuration = configuration;
        _environment = webHostEnvironment;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        if (_environment.IsDevelopment())
        {
            if (Configuration.GetValue<bool>("MigrateDatabase"))
            {
                services.AddHostedService<DatabaseMigrator>();
            }

            if (Configuration.GetValue<bool>("SeedDummyData"))
            {
            }
        }

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                Configuration.Bind("API", options);
            });

        services.AddCors(options =>
        {
            options.AddPolicy(AllowAllOriginsCorsPolicy,
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        services.AddMvc(config =>
        {
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            config.Filters.Add(new AuthorizeFilter(policy));
        }).AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        // this to solve "Multipart body length limit exceeded"
        services.Configure<FormOptions>(x =>
        {
            x.ValueLengthLimit = int.MaxValue;
            x.MultipartBodyLengthLimit = int.MaxValue;
        });

        services.AddControllers()
            .AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblies
                (
                    new List<Assembly>
                    {
                        typeof(IQueryMarker).GetTypeInfo().Assembly,
                        typeof(ICommandMarker).GetTypeInfo().Assembly,
                        typeof(Startup).Assembly,
                    }
                );
                fv.DisableDataAnnotationsValidation = true;
            });

        var scopes = Configuration.GetSection("Swagger:Scopes")?.Get<Dictionary<string, string>>() ?? new Dictionary<string, string>();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lighthouse Construction Progress API", Version = "v1" });

            //Define the OAuth2.0 scheme that's in use (i.e. Implicit Flow)
            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri(Configuration["Swagger:AuthorizationUrl"]),
                        Scopes = scopes
                    }
                }
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                    },
                    scopes.Keys.ToArray()
                }
            });

            c.OperationFilter<AddRoleDocumentation>();
        });

        services.ConfigureSwaggerGen(options =>
        {
            options.CustomSchemaIds(x => x.FullName);
        });

        services.AddFluentValidationRulesToSwagger();

        services.AddResponseCompression(options =>
        {
            var o = new GzipCompressionProviderOptions
            {
                Level = CompressionLevel.Optimal
            };

            options.Providers.Add(new GzipCompressionProvider(o));
            options.Providers.Add<BrotliCompressionProvider>();
            options.EnableForHttps = true;

        });

        services.AddApplicationInsightsTelemetry();
        services.AddMediatrModules();
        services.AddApplicationModules(Configuration);
        services.AddQueryApplication();

        services.AddHostedService<VerifyPreservationApiClientExists>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseResponseCompression();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseGlobalExceptionHandling();

        app.UseCors(AllowAllOriginsCorsPolicy);

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lighthouse Construction Progress API");
            c.DocExpansion(DocExpansion.List);
            c.DisplayRequestDuration();

            c.OAuthClientId(Configuration["Swagger:ClientId"]);
            c.OAuthAppName("Lighthouse Construction API V1");
            c.OAuthScopeSeparator(" ");
            c.OAuthAdditionalQueryStringParams(new Dictionary<string, string> { { "resource", Configuration["API:Audience"] } });
        });

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCurrentPlant();
        app.UseCurrentBearerToken();
        app.UseAuthentication();
        app.UseCurrentUser();
        app.UsePersonValidator();
        app.UsePlantValidator();
        app.UseVerifyOidInDb();
        app.UseAuthorization();

        

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
