using System;
using System.Linq;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ResponsibleAggregate;
using Equinor.Lighthouse.Api.Infrastructure;
using Equinor.Lighthouse.Api.Infrastructure.Repositories;
using Equinor.Lighthouse.Api.WebApi.Misc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Equinor.Lighthouse.Api.WebApi.IntegrationTests
{
    public static class PreservationContextExtension
    {
        private static string _seederOid = "00000000-0000-0000-0000-999999999999";

        public static void CreateNewDatabaseWithCorrectSchema(this ApplicationContext dbContext)
        {
            var migrations = dbContext.Database.GetPendingMigrations();
            if (migrations.Any())
            {
                dbContext.Database.Migrate();
            }
        }

        public static void Seed(this ApplicationContext dbContext, IServiceProvider serviceProvider, KnownTestData knownTestData)
        {
            var userProvider = serviceProvider.GetRequiredService<CurrentUserProvider>();
            var plantProvider = serviceProvider.GetRequiredService<PlantProvider>();
            userProvider.SetCurrentUserOid(new Guid(_seederOid));
            plantProvider.SetPlant(knownTestData.Plant);
            
            /* 
             * Add the initial seeder user. Don't do this through the UnitOfWork as this expects/requires the current user to exist in the database.
             * This is the first user that is added to the database and will not get "Created" and "CreatedBy" data.
             */
            var seeder = EnsureCurrentUserIsSeeded(dbContext, userProvider);

            var plant = plantProvider.Plant;

            var responsible = SeedResponsible(dbContext, plant);

            dbContext.SaveChangesAsync().Wait();

            dbContext.SaveChangesAsync().Wait();
            
        }



        private static Person EnsureCurrentUserIsSeeded(ApplicationContext dbContext, ICurrentUserProvider userProvider)
        {
            var personRepository = new PersonRepository(dbContext);
            var person = personRepository.GetByOidAsync(userProvider.GetCurrentUserOid()).Result ??
                         SeedCurrentUserAsPerson(dbContext, userProvider);
            return person;
        }

        private static Person SeedCurrentUserAsPerson(ApplicationContext dbContext, ICurrentUserProvider userProvider)
        {
            var personRepository = new PersonRepository(dbContext);
            var person = new Person(userProvider.GetCurrentUserOid(), "Siri", "Seed");
            personRepository.Add(person);
            dbContext.SaveChangesAsync().Wait();
            return person;
        }

        private static Project SeedProject(ApplicationContext dbContext, string plant)
        {
            var projectRepository = new ProjectRepository(dbContext);
            var project = new Project(plant, KnownTestData.ProjectName, KnownTestData.ProjectDescription);
            projectRepository.Add(project);
            dbContext.SaveChangesAsync().Wait();
            return project;
        }

        private static Responsible SeedResponsible(ApplicationContext dbContext, string plant)
        {
            var responsibleRepository = new ResponsibleRepository(dbContext);
            var responsible = new Responsible(plant, KnownTestData.ResponsibleCode, KnownTestData.ResponsibleDescription);
            responsibleRepository.Add(responsible);
            dbContext.SaveChangesAsync().Wait();
            return responsible;
        }
    }
}
