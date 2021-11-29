using System.Linq;

namespace Equinor.Lighthouse.Api.Domain
{
    public interface IReadOnlyContext
    {
        IQueryable<TEntity> QuerySet<TEntity>() where TEntity : class;
    }
}
