using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.Domain.AggregateModels.ResponsibleAggregate
{
    public interface IResponsibleRepository : IRepository<Responsible>
    {
        Task<Responsible?> GetByCodeAsync(string responsibleCode);
    }
}
