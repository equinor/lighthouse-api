using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate;
using Microsoft.EntityFrameworkCore;

namespace Equinor.Lighthouse.Api.Infrastructure.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationContext context)
            : base(context, context.Projects, context.Projects)
        {
        }

        public Task<Project> GetProjectOnlyByNameAsync(string projectName)
            => Set.SingleOrDefaultAsync(p => p.Name == projectName);
    }
}
