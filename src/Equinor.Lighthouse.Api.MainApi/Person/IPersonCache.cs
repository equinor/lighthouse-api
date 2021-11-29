using System;
using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.MainApi.Person;

// todo unit tests
public interface IPersonCache
{
    Task<bool> ExistsAsync(Guid userOid);
    Task<PCSPerson> GetAsync(Guid userOid);
}