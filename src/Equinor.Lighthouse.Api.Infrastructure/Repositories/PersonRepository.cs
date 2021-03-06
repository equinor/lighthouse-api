using System;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Microsoft.EntityFrameworkCore;

namespace Equinor.Lighthouse.Api.Infrastructure.Repositories;

public class PersonRepository : RepositoryBase<Person>, IPersonRepository
{
    public PersonRepository(ApplicationContext context)
        : base(context, context.Persons) { }

    public Task<Person> GetByOidAsync(Guid oid)
        => DefaultQuery.SingleOrDefaultAsync(p => p.Oid == oid);

    public Task<Person> GetWithSavedFiltersByOidAsync(Guid oid)
        => DefaultQuery
            .Include(p => p.SavedFilters)
            .SingleOrDefaultAsync(p => p.Oid == oid);

    public void RemoveSavedFilter(SavedFilter? savedFilter)
        => _context.SavedFilters.Remove(savedFilter);
}
