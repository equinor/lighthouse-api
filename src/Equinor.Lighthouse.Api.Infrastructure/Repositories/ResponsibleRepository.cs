using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ResponsibleAggregate;
using Microsoft.EntityFrameworkCore;

namespace Equinor.Lighthouse.Api.Infrastructure.Repositories;

public class ResponsibleRepository : RepositoryBase<Responsible>, IResponsibleRepository
{
    public ResponsibleRepository(ApplicationContext context) : base(context, context.Responsibles)
    {
    }
        
    public Task<Responsible?> GetByCodeAsync(string responsibleCode) 
        => DefaultQuery.SingleOrDefaultAsync(r => r.Code == responsibleCode);
}
