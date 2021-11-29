using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain.AggregateModels.SettingAggregate;
using Equinor.Lighthouse.Api.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockQueryable.Moq;

namespace Equinor.Lighthouse.Api.Infrastructure.Tests.Repositories
{
    [TestClass]
    public class SettingRepositoryTests : RepositoryTestBase
    {
        private readonly string _settingCode = "A";
        private SettingRepository _dut;

        [TestInitialize]
        public void Setup()
        {
            var setting = new Setting(TestPlant, _settingCode);

            var settings = new List<Setting> {setting};

            var dbSetMock = settings.AsQueryable().BuildMockDbSet();

            ContextHelper
                .ContextMock
                .Setup(x => x.Settings)
                .Returns(dbSetMock.Object);

            _dut = new SettingRepository(ContextHelper.ContextMock.Object);
        }

        [TestMethod]
        public async Task GetByCode_ShouldReturnSetting_WhenSettingExists()
        {
            var result = await _dut.GetByCodeAsync(_settingCode);

            // Assert
            Assert.AreEqual(_settingCode, result.Code);
        }

        [TestMethod]
        public async Task GetByCode_ShouldReturnNull_WhenSettingNotExists()
        {
            var result = await _dut.GetByCodeAsync("XYZ");

            // Assert
            Assert.IsNull(result);
        }
    }
}
