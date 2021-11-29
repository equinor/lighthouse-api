using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.MainApi.Permission;

public interface IPermissionApiService
{
    Task<IList<string>> GetPermissionsAsync(string plantId);
    Task<IList<PCSProject>> GetAllOpenProjectsAsync(string plantId);
    Task<IList<string>> GetContentRestrictionsAsync(string plantId);
}