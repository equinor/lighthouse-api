using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate;
using Microsoft.EntityFrameworkCore;

namespace Equinor.Lighthouse.Api.Command.Validators.ProjectValidators;

public class ProjectValidator : IProjectValidator
{
    private readonly IReadOnlyContext _context;

    public ProjectValidator(IReadOnlyContext context) => _context = context;

    public async Task<bool> ExistsAsync(string projectName, CancellationToken cancellationToken) =>
        await (from p in _context.QuerySet<Project>()
            where p.Name == projectName
            select p).AnyAsync(cancellationToken);

    public async Task<bool> IsExistingAndClosedAsync(string projectName, CancellationToken cancellationToken)
    {
        var project = await (from p in _context.QuerySet<Project>()
            where p.Name == projectName
            select p).SingleOrDefaultAsync(cancellationToken);

        return project != null && project.IsClosed;
    }

}
