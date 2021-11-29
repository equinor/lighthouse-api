using System.Collections.Generic;
using System.Net.Http;
using Equinor.Lighthouse.Api.MainApi.Permission;
using Equinor.Lighthouse.Api.MainApi.Person;
using Equinor.Lighthouse.Api.MainApi.Plant;

namespace Equinor.Lighthouse.Api.WebApi.IntegrationTests
{
    public interface ITestUser
    {
        TokenProfile Profile { get; set; }
        PCSPerson ProCoSysPerson { get; set; }
        List<PCSPlant> ProCoSysPlants { get; set; }
        List<PCSProject> ProCoSysProjects { get; set; }
        List<string> ProCoSysPermissions { get; set; }
        List<string> ProCoSysRestrictions { get; set; }
        HttpClient HttpClient { get; set; }
    }
}
