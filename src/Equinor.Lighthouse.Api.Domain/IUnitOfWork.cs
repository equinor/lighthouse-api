using System.Threading;
using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.Domain
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
