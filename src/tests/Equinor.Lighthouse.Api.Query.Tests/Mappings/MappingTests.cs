using System;
using System.Runtime.Serialization;
using AutoMapper;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate;
using Equinor.Lighthouse.Api.Query.Activities;
using Equinor.Lighthouse.Api.Query.LciObjects;
using Equinor.Lighthouse.Api.Query.Mappings;
using Equinor.Lighthouse.Api.Query.WorkOrders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Equinor.Lighthouse.Api.Query.Tests.Mappings;

[TestClass]
public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;
   
    public MappingTests()
    {
        _configuration = new MapperConfiguration(config =>
            config.AddProfile<MappingProfile>());

        _mapper = _configuration.CreateMapper();
    }

    [TestMethod]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [TestMethod]
    [DataRow(typeof(WorkOrder), typeof(WorkOrderDto))]
    [DataRow(typeof(Activity), typeof(ActivityDto))]
    [DataRow(typeof(LciObject), typeof(LciObjectDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private static object GetInstanceOf(Type type)
    {
        return type.GetConstructor(Type.EmptyTypes) != null 
            ? Activator.CreateInstance(type)! 
            : FormatterServices.GetUninitializedObject(type);
    }
}
