using System.Linq;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Equinor.Lighthouse.Api.Domain.Tests
{
    [TestClass]
    public class EntityBaseTests
    {
        private readonly byte[] ConvertedRowVersion = {0, 0, 0, 0, 0, 0, 0, 16};
        private const string RowVersion = "AAAAAAAAABA=";

        [TestMethod]
        public void ReturningEmptyDomainEventsListTest()
        {
            var dut = new TestableEntityBase();
            Assert.IsNotNull(dut.DomainEvents);
        }

        [TestMethod]
        public void DomainEventIsAddedToListTest()
        {
            var dut = new TestableEntityBase();
            var domainEvent = new Mock<INotification>();
            dut.AddDomainEvent(domainEvent.Object);

            Assert.IsTrue(dut.DomainEvents.Contains(domainEvent.Object));
        }

        [TestMethod]
        public void DomainEventIsRemovedFromListTest()
        {
            var dut = new TestableEntityBase();
            var domainEvent = new Mock<INotification>();
            dut.AddDomainEvent(domainEvent.Object);
            dut.RemoveDomainEvent(domainEvent.Object);

            Assert.IsFalse(dut.DomainEvents.Contains(domainEvent.Object));
        }

        [TestMethod]
        public void DomainEventsAreClearedTest()
        {
            var dut = new TestableEntityBase();
            var domainEvent1 = new Mock<INotification>();
            dut.AddDomainEvent(domainEvent1.Object);
            var domainEvent2 = new Mock<INotification>();
            dut.AddDomainEvent(domainEvent2.Object);

            dut.ClearDomainEvents();

            Assert.AreEqual(0, dut.DomainEvents.Count);
        }

        [TestMethod]
        public void GetRowVersion_ShouldReturnLastSetRowVersion()
        {
            var dut = new TestableEntityBase();
            Assert.IsNotNull(dut.RowVersion);
            dut.SetRowVersion(RowVersion);
            Assert.IsTrue(dut.RowVersion.SequenceEqual(ConvertedRowVersion));
        }
       
        private class TestableEntityBase : EntityBase
        {
            // The base class is abstract, therefor a sub class is needed to test it.
        }
    }
}
