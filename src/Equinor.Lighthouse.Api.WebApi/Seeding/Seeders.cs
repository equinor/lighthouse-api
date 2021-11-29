using System;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ResponsibleAggregate;

namespace Equinor.Lighthouse.Api.WebApi.Seeding
{
    public static class Seeders
    {
        public static void AddUsers(this IPersonRepository personRepository, int entryCount)
        {
            for (var i = 0; i < entryCount; i++)
            {
                var user = new Person(Guid.NewGuid(), $"Firstname-{i}", $"Lastname-{i}");
                personRepository.Add(user);
            }
        }

        public static void AddResponsibles(this IResponsibleRepository responsibleRepository, int entryCount, string plant)
        {
            for (var i = 0; i < entryCount; i++)
            {
                var responsible = new Responsible(plant, $"ResponsibleCode-{i}", $"ResponsibleDesc-{i}");
                responsibleRepository.Add(responsible);
            }
        }

        public static void AddProjects(this IProjectRepository projectRepository, int entryCount, string plant)
        {
            for (var i = 0; i < entryCount; i++)
            {
                var project = new Project(plant, $"Project-{i}", "Decription");
                projectRepository.Add(project);
            }
        }

    }
}
