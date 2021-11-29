using System;
using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.MainApi.Person;

public interface IPersonApiService
{
    Task<PCSPerson> TryGetPersonByOidAsync(Guid azureOid);
}
