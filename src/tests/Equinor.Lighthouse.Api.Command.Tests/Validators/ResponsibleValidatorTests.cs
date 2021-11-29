using System.Linq;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Command.Validators.ResponsibleValidators;
using Equinor.Lighthouse.Api.Infrastructure;
using Equinor.Lighthouse.Api.Test.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Equinor.Lighthouse.Api.Command.Tests.Validators
{
    [TestClass]
    public class ResponsibleValidatorTests : ReadOnlyTestsBase
    {
        private string _responsibleCode;

        protected override void SetupNewDatabase(DbContextOptions<ApplicationContext> dbContextOptions)
        {
            using (var context = new ApplicationContext(dbContextOptions, _plantProvider, _eventDispatcher,
                _currentUserProvider))
            {
                _responsibleCode = AddResponsible(context, "R").Code;
            }
        }

        [TestMethod]
        public async Task ExistsAndIsVoidedAsync_KnownCode_Voided_ShouldReturnTrue()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher, _currentUserProvider))
            {
                var responsible = context.Responsibles.Single(r => r.Code == _responsibleCode);
                responsible.IsVoided = true;
                context.SaveChangesAsync().Wait();
            }

            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher,
                _currentUserProvider))
            {
                var dut = new ResponsibleValidator(context);
                var result = await dut.ExistsAndIsVoidedAsync(_responsibleCode, default);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task ExistsAndIsVoidedAsync_KnownCode_NotVoided_ShouldReturnFalse()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher,
                _currentUserProvider))
            {
                var dut = new ResponsibleValidator(context);
                var result = await dut.ExistsAndIsVoidedAsync(_responsibleCode, default);
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public async Task ExistsAndIsVoidedAsync_UnknownCode_ShouldReturnFalse()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher,
                _currentUserProvider))
            {
                var dut = new ResponsibleValidator(context);
                var result = await dut.ExistsAndIsVoidedAsync("A", default);
                Assert.IsFalse(result);
            }
        }
    }
}
