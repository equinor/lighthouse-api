using System;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Equinor.Lighthouse.Api.Domain.Events;
using Equinor.Lighthouse.Api.Domain.Time;
using Equinor.Lighthouse.Api.Test.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Equinor.Lighthouse.Api.Infrastructure.Tests
{
    [TestClass]
    public class UnitOfWorkTests
    {
        private const string Plant = "PCS$TESTPLANT";
        private readonly Guid _currentUserOid = new Guid("12345678-1234-1234-1234-123456789123");
        private readonly DateTime _currentTime = new DateTime(2020, 2, 1, 0, 0, 0, DateTimeKind.Utc);
        private DbContextOptions<ApplicationContext> _dbContextOptions;
        private Mock<IPlantProvider> _plantProviderMock;
        private Mock<IEventDispatcher> _eventDispatcherMock;
        private Mock<ICurrentUserProvider> _currentUserProviderMock;
        private ManualTimeProvider _timeProvider;

        [TestInitialize]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _plantProviderMock = new Mock<IPlantProvider>();
            _plantProviderMock.Setup(x => x.Plant)
                .Returns(Plant);

            _eventDispatcherMock = new Mock<IEventDispatcher>();

            _currentUserProviderMock = new Mock<ICurrentUserProvider>();

            _timeProvider = new ManualTimeProvider(new DateTime(2020, 2, 1, 0, 0, 0, DateTimeKind.Utc));
            TimeService.SetProvider(_timeProvider);
        }

        [TestMethod]
        public async Task SaveChangesAsync_SetsCreatedProperties_WhenCreated()
        {
            using var dut = new ApplicationContext(_dbContextOptions, _plantProviderMock.Object, _eventDispatcherMock.Object, _currentUserProviderMock.Object);

            var user = new Person(_currentUserOid, "Current", "User");
            dut.Persons.Add(user);
            dut.SaveChanges();

            _currentUserProviderMock
                .Setup(x => x.GetCurrentUserOid())
                .Returns(_currentUserOid);

            await dut.SaveChangesAsync();
        }

        [TestMethod]
        public async Task SaveChangesAsync_SetsModifiedProperties_WhenModified()
        {
            using var dut = new ApplicationContext(_dbContextOptions, _plantProviderMock.Object, _eventDispatcherMock.Object, _currentUserProviderMock.Object);

            var user = new Person(_currentUserOid, "Current", "User");
            dut.Persons.Add(user);
            dut.SaveChanges();

            _currentUserProviderMock
                .Setup(x => x.GetCurrentUserOid())
                .Returns(_currentUserOid);

            await dut.SaveChangesAsync();
        }
    }
}
