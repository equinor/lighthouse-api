using Equinor.Lighthouse.Api.Command.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Equinor.Lighthouse.Api.WebApi.IntegrationTests
{
    [TestClass]
    public abstract class TestBase
    {
        private readonly RowVersionValidator _rowVersionValidator = new RowVersionValidator();
        
        [AssemblyCleanup]
        public static void AssemblyCleanup() => TestFactory.Instance.Dispose();

        public void AssertRowVersionChange(string oldRowVersion, string newRowVersion)
        {
            Assert.IsTrue(_rowVersionValidator.IsValid(oldRowVersion));
            Assert.IsTrue(_rowVersionValidator.IsValid(newRowVersion));
            Assert.AreNotEqual(oldRowVersion, newRowVersion);
        }
    }
}
