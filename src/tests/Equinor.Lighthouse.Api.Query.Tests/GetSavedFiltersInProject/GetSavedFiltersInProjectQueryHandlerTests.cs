using System.Linq;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate;
using Equinor.Lighthouse.Api.Infrastructure;
using Equinor.Lighthouse.Api.Query.GetSavedFiltersInProject;
using Equinor.Lighthouse.Api.Test.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Query.Tests.GetSavedFiltersInProject
{
    [TestClass]
    public class GetSavedFiltersInProjectQueryHandlerTests : ReadOnlyTestsBase
    {
        private GetSavedFiltersInProjectQuery _query;

        private const string _title = "title";
        private const string _criteria = "criteria in JSON";
        private const string _projectName = "projectName";
        private bool _defaultFilter = true;

        private SavedFilter _savedFilter;
        private Person _person;
        private Project _project;

        protected override void SetupNewDatabase(DbContextOptions<ApplicationContext> dbContextOptions)
        {
            using (var context = new ApplicationContext(dbContextOptions, _plantProvider, _eventDispatcher,
                _currentUserProvider))
            {
                _query = new GetSavedFiltersInProjectQuery(_projectName);

                _project = AddProject(context, _projectName, "", true);

                _savedFilter = new SavedFilter(TestPlant, _project, _title, _criteria)
                    { DefaultFilter =  _defaultFilter };
                _person = context.Persons.Single(p => p.Oid == _currentUserOid);
                _person.AddSavedFilter(_savedFilter);

                context.SaveChangesAsync().Wait();
            }
        }

        [TestMethod]
        public async Task HandleGetSavedFiltersInProjectQuery_ShouldReturnOkResult()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher,
                _currentUserProvider))
            {
                var dut = new GetSavedFiltersInProjectQueryHandler(context, _currentUserProvider);
                var result = await dut.Handle(_query, default);

                Assert.AreEqual(ResultType.Ok, result.ResultType);
            }
        }

        [TestMethod]
        public async Task HandleGetSavedFiltersInProjectQuery_ShouldReturnCorrectSavedFilters()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher,
                _currentUserProvider))
            {
                var dut = new GetSavedFiltersInProjectQueryHandler(context, _currentUserProvider);

                var result = await dut.Handle(_query, default);
                var savedFilter = result.Data.Single();

                Assert.AreEqual(1, result.Data.Count);
                Assert.AreEqual(_savedFilter.Id, savedFilter.Id);
                Assert.AreEqual(_savedFilter.Title, savedFilter.Title);
                Assert.AreEqual(_savedFilter.Criteria, savedFilter.Criteria);
                Assert.AreEqual(_savedFilter.DefaultFilter, savedFilter.DefaultFilter);
            }
        }

        [TestMethod]
        public async Task HandleGetSavedFiltersInProjectQuery_ShouldReturnEmptyListOfSavedFilters_ForProjectWithoutSavedFilters()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher,
                _currentUserProvider))
            {
                var dut = new GetSavedFiltersInProjectQueryHandler(context, _currentUserProvider);

                var result = await dut.Handle(new GetSavedFiltersInProjectQuery("Unknownproject"), default);
                Assert.AreEqual(0, result.Data.Count);
            }
        }
    }
}
