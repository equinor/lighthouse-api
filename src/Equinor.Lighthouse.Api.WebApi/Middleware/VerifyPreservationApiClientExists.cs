using System;
using System.Threading;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Command.PersonCommands.CreatePerson;
using Equinor.Lighthouse.Api.WebApi.Authentication;
using Equinor.Lighthouse.Api.WebApi.Misc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Equinor.Lighthouse.Api.WebApi.Middleware;

public class VerifyPreservationApiClientExists : IHostedService
{
    private readonly IServiceScopeFactory _serviceProvider;
    private readonly IOptions<AuthenticatorOptions> _options;
    private readonly ILogger<VerifyPreservationApiClientExists> _logger;

    public VerifyPreservationApiClientExists(
        IServiceScopeFactory serviceProvider,
        IOptions<AuthenticatorOptions> options, 
        ILogger<VerifyPreservationApiClientExists> logger)
    {
        _serviceProvider = serviceProvider;
        _options = options;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();

        var mediator =
            scope.ServiceProvider
                .GetRequiredService<IMediator>();
        var currentUserSetter =
            scope.ServiceProvider
                .GetRequiredService<ICurrentUserSetter>();

        var oid = _options.Value.LighthouseApiObjectId;
        _logger.LogInformation($"Ensuring '{oid}' exists as Person");
        try
        {
            currentUserSetter.SetCurrentUserOid(oid);
            await mediator.Send(new CreatePersonCommand(oid), cancellationToken);
            _logger.LogInformation($"'{oid}' ensured");
        }
        catch (Exception e)
        {
            _logger.LogError($"Exception handling {nameof(CreatePersonCommand)}", e);
            throw;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
