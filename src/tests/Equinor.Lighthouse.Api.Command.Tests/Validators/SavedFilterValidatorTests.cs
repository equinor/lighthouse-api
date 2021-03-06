using System;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Command.Validators.SavedFilterValidators;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate;
using Equinor.Lighthouse.Api.Test.Common;
using Moq;

namespace Equinor.Lighthouse.Api.Command.Tests.Validators
{
    [TestClass]
    public class SavedFilterValidatorTests : ReadOnlyTestsBase
    {
        private Mock<ICurrentUserProvider> _currentUserProviderMock;
        private Guid _personOid;
        private SavedFilterValidator _dut;
        private Project _project;
        private SavedFilter _savedFilter1;
        private SavedFilter _savedFilter2;

        private readonly string _title = "title";
        private readonly string _projectName = "projectName";

        protected override void SetupNewDatabase(DbContextOptions<ApplicationContext> dbContextOptions)
        {
            using var context = new ApplicationContext(dbContextOptions, _plantProvider, _eventDispatcher,
                _currentUserProvider);
            const string Criteria = "criteria";
            _personOid = new Guid();

            _project = AddProject(context, _projectName, "");

            var person = AddPerson(context, _personOid, "Current", "User");
            _savedFilter1 = new SavedFilter(TestPlant, _project, _title, Criteria);
            _savedFilter2 = new SavedFilter(TestPlant, _project, _title, "C");

            person.AddSavedFilter(_savedFilter1);
            person.AddSavedFilter(_savedFilter2);
            context.SaveChangesAsync().Wait();

            _currentUserProviderMock = new Mock<ICurrentUserProvider>();
            _currentUserProviderMock
                .Setup(x => x.GetCurrentUserOid())
                .Returns(_personOid);
        }

        [TestMethod]
        public async Task ExistsWithSameTitleForPersonInProjectAsync_UnknownTitle_ShouldReturnFalse()
        {
            await using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher,
                             _currentUserProvider))
            {
                _dut = new SavedFilterValidator(context, _currentUserProviderMock.Object);
                var result = await _dut.ExistsWithSameTitleForPersonInProjectAsync("xxx", _projectName, default);

                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public async Task ExistsWithSameTitleForPersonInProjectAsync_KnownTitle_ShouldReturnTrue()
        {
            await using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher,
                             _currentUserProvider))
            {
                _dut = new SavedFilterValidator(context, _currentUserProviderMock.Object);
                var result = await _dut.ExistsWithSameTitleForPersonInProjectAsync(_title, _projectName, default);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task ExistsAnotherWithSameTitleForPersonInProjectAsync_NewTitle_ShouldReturnFalse()
        {
            await using var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher,
                _currentUserProvider);
            _dut = new SavedFilterValidator(context, _currentUserProviderMock.Object);
            var result = await _dut.ExistsAnotherWithSameTitleForPersonInProjectAsync(new Guid("2"), "xxx", default);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task ExistsAnotherWithSameTitleForPersonInProjectAsync_SameTitleAsAnotherSavedFilter_ShouldReturnTrue()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher,
                _currentUserProvider))
            {
                _dut = new SavedFilterValidator(context, _currentUserProviderMock.Object);
                var result = await _dut.ExistsAnotherWithSameTitleForPersonInProjectAsync(_savedFilter2.Id, _title, default);

                Assert.IsTrue(result);
            }
        }
    }
}
