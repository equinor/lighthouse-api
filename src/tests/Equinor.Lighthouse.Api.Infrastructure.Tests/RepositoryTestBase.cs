using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Equinor.Lighthouse.Api.Infrastructure.Tests
{
    [TestClass]
    public class RepositoryTestBase
    {
        protected const string TestPlant = "PCS$TESTPLANT";
        protected ContextHelper ContextHelper;
        
        [TestInitialize]
        public void RepositorySetup() => ContextHelper = new ContextHelper();
    }
}
