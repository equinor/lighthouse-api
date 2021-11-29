using System;
using Equinor.Lighthouse.Api.Query.ResponsibleAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Equinor.Lighthouse.Api.Query.Tests.ResponsibleAggregate
{
    [TestClass]
    public class ResponsibleDtoTests
    {
        [TestMethod]
        public void Constructor_ShouldSetProperties()
        {
            var dut = new ResponsibleDto(new Guid("3"), "RC", "RD", "AAAAAAAAABA=");

            Assert.AreEqual(3, dut.Id);
            Assert.AreEqual("RC", dut.Code);
            Assert.AreEqual("RD", dut.Description);
            Assert.AreEqual("AAAAAAAAABA=", dut.RowVersion);
        }
    }
}
