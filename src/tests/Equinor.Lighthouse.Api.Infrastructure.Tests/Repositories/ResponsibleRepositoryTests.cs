using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ResponsibleAggregate;
using Equinor.Lighthouse.Api.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockQueryable.Moq;

namespace Equinor.Lighthouse.Api.Infrastructure.Tests.Repositories;

[TestClass]
public class ResponsibleRepositoryTests : RepositoryTestBase
{
    private const string ResponsibleCode = "A";

    private ResponsibleRepository _dut;

    [TestInitialize]
    public void Setup()
    {
        var responsible = new Responsible(TestPlant, ResponsibleCode, "Desc");

        var responsibles = new List<Responsible> { responsible };

        var dbSetMock = responsibles.AsQueryable().BuildMockDbSet();

        ContextHelper
            .ContextMock
            .Setup(x => x.Responsibles)
            .Returns(dbSetMock.Object);

        _dut = new ResponsibleRepository(ContextHelper.ContextMock.Object);
    }

    [TestMethod]
    public async Task GetByCode_ShouldReturnResponsible_WhenResponsibleExists()
    {
        var result = await _dut.GetByCodeAsync(ResponsibleCode);

        // Assert
        Assert.AreEqual(ResponsibleCode, result.Code);
    }

    [TestMethod]
    public async Task GetByCode_ShouldReturnNull_WhenResponsibleNotExists()
    {
        var result = await _dut.GetByCodeAsync("XYZ");

        // Assert
        Assert.IsNull(result);
    }
}
