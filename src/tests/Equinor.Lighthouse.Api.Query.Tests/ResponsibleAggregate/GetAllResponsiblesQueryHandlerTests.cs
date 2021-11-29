using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ResponsibleAggregate;
using Equinor.Lighthouse.Api.Infrastructure;
using Equinor.Lighthouse.Api.Query.ResponsibleAggregate;
using Equinor.Lighthouse.Api.Test.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Equinor.Lighthouse.Api.Query.Tests.ResponsibleAggregate
{
    [TestClass]
    public class GetAllResponsiblesQueryHandlerTests : ReadOnlyTestsBase
    {
        private Responsible _responsible;

        protected override void SetupNewDatabase(DbContextOptions<ApplicationContext> dbContextOptions)
        {
            using (var context = new ApplicationContext(dbContextOptions, _plantProvider, _eventDispatcher, _currentUserProvider))
            {
                _responsible = AddResponsible(context, "R");
            }
        }

        [TestMethod]
        public async Task HandleGetAllResponsiblesQueryHandler_ShouldReturnResponsibles()
        {
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher, _currentUserProvider))
            {
                var _dut = new GetAllResponsiblesQueryHandler(context);
                var result = await _dut.Handle(new GetAllResponsiblesQuery(), default);

                var responsibles = result.Data.ToList();

                Assert.AreEqual(1, responsibles.Count);
                var responsibleDto = responsibles.Single();
                Assert.AreEqual(_responsible.Code, responsibleDto.Code);
                Assert.AreEqual(_responsible.Description, responsibleDto.Description);
            }
        }
    }
}
