using System;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.MainApi.Client;
using Equinor.Lighthouse.Api.MainApi.Person;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Equinor.Lighthouse.Api.MainApi.Tests.Person
{
    [TestClass]
    public class MainApiPersonServiceTests
    {
        private readonly Guid _azureOid = Guid.NewGuid();
        private MainApiPersonService _dut;
        private Mock<IAuthenticator> _authenticator;
        private readonly string _firstname = "Espen";
        private readonly string _lastname = "Askeladd";

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            var mainApiOptions = new Mock<IOptionsMonitor<MainApiOptions>>();
            mainApiOptions
                .Setup(x => x.CurrentValue)
                .Returns(new MainApiOptions { ApiVersion = "4.0", BaseAddress = "http://example.com" });
            var mainApiClient = new Mock<IBearerTokenApiClient>();
            _authenticator = new Mock<IAuthenticator>();
            mainApiClient
                .Setup(x => x.TryQueryAndDeserializeAsync<PCSPerson>(It.IsAny<string>()))
                .Returns(Task.FromResult(new PCSPerson
                {
                    AzureOid = _azureOid.ToString("D"),
                    FirstName = _firstname,
                    LastName = _lastname
                }));

            _dut = new MainApiPersonService(_authenticator.Object, mainApiClient.Object, mainApiOptions.Object);
        }

        [TestMethod]
        public async Task TryGetPersonsByOid_ShouldGetPerson()
        {
            // Act
            var result = await _dut.TryGetPersonByOidAsync(_azureOid);

            // Assert
            Assert.AreEqual(_azureOid.ToString("D"), result.AzureOid);
            Assert.AreEqual(_firstname, result.FirstName);
            Assert.AreEqual(_lastname, result.LastName);
        }

        [TestMethod]
        public async Task TryGetPersonsByOid_ShouldSetApplicationAuthentication()
        {
            // Act
            await _dut.TryGetPersonByOidAsync(_azureOid);

            // Assert
            _authenticator.VerifySet(a => a.AuthenticationType = AuthenticationType.AsApplication);
        }

        [TestMethod]
        public async Task TryGetPersonsByOid_ShouldResetToOnBehalfOfAuthentication()
        {
            // Act
            await _dut.TryGetPersonByOidAsync(_azureOid);

            // Assert
            _authenticator.VerifySet(a => a.AuthenticationType = AuthenticationType.OnBehalfOf);
        }
    }
}
