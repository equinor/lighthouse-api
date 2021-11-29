using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Command.Validators.ProjectValidators;
using Equinor.Lighthouse.Api.Infrastructure;
using Equinor.Lighthouse.Api.Test.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Equinor.Lighthouse.Api.Command.Tests.Validators
{
    [TestClass]
    public class ProjectValidatorTests : ReadOnlyTestsBase
    {
        private const string ProjectNameNotClosed = "Project name";
        private const string ProjectNameClosed = "Project name (closed)";
        private int _tagInClosedProjectId;
        private int _tag1InNotClosedProjectId;
        private int _tag2InNotClosedProjectId;

        protected override void SetupNewDatabase(DbContextOptions<ApplicationContext> dbContextOptions)
        {
    
        }

        [TestMethod]
        public async Task ExistsAsync_KnownName_ShouldReturnTrue()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher, _currentUserProvider))
            {
                var dut = new ProjectValidator(context);
                var result = await dut.ExistsAsync(ProjectNameNotClosed, default);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task ExistsAsync_UnknownName_ShouldReturnFalse()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher, _currentUserProvider))
            {
                var dut = new ProjectValidator(context);
                var result = await dut.ExistsAsync("XX", default);
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public async Task IsExistingAndClosedAsync_KnownClosed_ShouldReturnTrue()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher, _currentUserProvider))
            {
                var dut = new ProjectValidator(context);
                var result = await dut.IsExistingAndClosedAsync(ProjectNameClosed, default);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task IsExistingAndClosedAsync_KnownNotClosed_ShouldReturnFalse()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher, _currentUserProvider))
            {
                var dut = new ProjectValidator(context);
                var result = await dut.IsExistingAndClosedAsync(ProjectNameNotClosed, default);
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public async Task IsExistingAndClosedAsync_UnknownName_ShouldReturnFalse()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher, _currentUserProvider))
            {
                var dut = new ProjectValidator(context);
                var result = await dut.IsExistingAndClosedAsync("XX", default);
                Assert.IsFalse(result);
            }
        }
    }
}
