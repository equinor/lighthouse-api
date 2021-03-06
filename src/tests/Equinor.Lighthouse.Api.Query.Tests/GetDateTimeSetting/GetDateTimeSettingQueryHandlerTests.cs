using System;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain.AggregateModels.SettingAggregate;
using Equinor.Lighthouse.Api.Infrastructure;
using Equinor.Lighthouse.Api.Query.GetDateTimeSetting;
using Equinor.Lighthouse.Api.Test.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Query.Tests.GetDateTimeSetting
{
    [TestClass]
    public class GetDateTimeSettingQueryHandlerTests : ReadOnlyTestsBase
    {
        private readonly string _codeWithDate = "Code1";
        private readonly string _codeWithoutDate = "Code2";
        private readonly DateTime _dt = new DateTime(1999, 1, 2, 0, 0, 0, DateTimeKind.Utc);

        protected override void SetupNewDatabase(DbContextOptions<ApplicationContext> dbContextOptions)
        {
            using (var context = new ApplicationContext(dbContextOptions, _plantProvider, _eventDispatcher, _currentUserProvider))
            {
                var setting1 = new Setting(TestPlant, _codeWithoutDate);
                context.Settings.Add(setting1);
                
                var setting2 = new Setting(TestPlant, _codeWithDate);
                setting2.SetDateTime(_dt);
                
                context.Settings.Add(setting2);
                context.SaveChangesAsync().Wait();
            }
        }

        [TestMethod]
        public async Task HandleGetDateTimeSettingQueryHandler_CodeWithoutDate_ShouldReturnNullAsDate()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher, _currentUserProvider))
            {
                var dut = new GetDateTimeSettingQueryHandler(context);
                var result = await dut.Handle(new GetDateTimeSettingQuery(_codeWithoutDate), default);

                Assert.AreEqual(ResultType.Ok, result.ResultType);

                var dt = result.Data;
                Assert.IsFalse(dt.HasValue);
            }
        }

        [TestMethod]
        public async Task HandleGetDateTimeSettingQueryHandler_CodeWithDate_ShouldReturnDate()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher, _currentUserProvider))
            {
                var dut = new GetDateTimeSettingQueryHandler(context);
                var result = await dut.Handle(new GetDateTimeSettingQuery(_codeWithDate), default);

                Assert.AreEqual(ResultType.Ok, result.ResultType);

                var dt = result.Data;
                Assert.IsTrue(dt.HasValue);
                Assert.AreEqual(_dt, dt.Value);
            }
        }

        [TestMethod]
        public async Task HandleGetDateTimeSettingQueryHandler_UnknownCode_ShouldReturnNotFound()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher, _currentUserProvider))
            {
                var dut = new GetDateTimeSettingQueryHandler(context);
                var result = await dut.Handle(new GetDateTimeSettingQuery("XYZ"), default);

                Assert.AreEqual(ResultType.NotFound, result.ResultType);
                Assert.IsNull(result.Data);
            }
        }
    }
}
