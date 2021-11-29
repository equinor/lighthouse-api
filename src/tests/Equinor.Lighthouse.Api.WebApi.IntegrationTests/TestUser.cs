using System.Collections.Generic;
using System.Net.Http;
using Equinor.Lighthouse.Api.MainApi.Permission;
using Equinor.Lighthouse.Api.MainApi.Person;
using Equinor.Lighthouse.Api.MainApi.Plant;

namespace Equinor.Lighthouse.Api.WebApi.IntegrationTests
{
    public class TestUser : ITestUser
    {
        public TokenProfile Profile { get; set; }
        public PCSPerson ProCoSysPerson { get; set; }
        public List<PCSPlant> ProCoSysPlants { get; set; }
        public List<PCSProject> ProCoSysProjects { get; set; }
        public List<string> ProCoSysPermissions { get; set; }
        public List<string> ProCoSysRestrictions { get; set; }
        public HttpClient HttpClient { get; set; }

        public override string ToString() => Profile?.ToString();
    }
}
