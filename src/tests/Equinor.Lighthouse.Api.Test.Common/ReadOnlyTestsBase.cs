using System;
using System.Collections.Generic;
using System.Linq;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ResponsibleAggregate;
using Equinor.Lighthouse.Api.Domain.Events;
using Equinor.Lighthouse.Api.Domain.Time;
using Equinor.Lighthouse.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Equinor.Lighthouse.Api.Test.Common
{
    public abstract class ReadOnlyTestsBase
    {
        protected const string TestPlant = "PCS$PlantA";
        protected readonly Guid _currentUserOid = new Guid("12345678-1234-1234-1234-123456789123");
        protected DbContextOptions<ApplicationContext> _dbContextOptions;
        protected Mock<IPlantProvider> _plantProviderMock;
        protected IPlantProvider _plantProvider;
        protected ICurrentUserProvider _currentUserProvider;
        protected IEventDispatcher _eventDispatcher;
        protected ManualTimeProvider _timeProvider;

        [TestInitialize]
        public void SetupBase()
        {
            _plantProviderMock = new Mock<IPlantProvider>();
            _plantProviderMock.SetupGet(x => x.Plant).Returns(TestPlant);
            _plantProvider = _plantProviderMock.Object;

            var currentUserProviderMock = new Mock<ICurrentUserProvider>();
            currentUserProviderMock.Setup(x => x.GetCurrentUserOid()).Returns(_currentUserOid);
            _currentUserProvider = currentUserProviderMock.Object;

            var eventDispatcher = new Mock<IEventDispatcher>();
            _eventDispatcher = eventDispatcher.Object;

            _timeProvider = new ManualTimeProvider(new DateTime(2020, 2, 1, 0, 0, 0, DateTimeKind.Utc));
            TimeService.SetProvider(_timeProvider);

            _dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            // ensure current user exists in db
            using (var context = new ApplicationContext(_dbContextOptions, _plantProvider, _eventDispatcher, _currentUserProvider))
            {
                if (context.Persons.SingleOrDefault(p => p.Oid == _currentUserOid) == null)
                {
                    AddPerson(context, _currentUserOid, "Ole", "Lukkøye");
                }
            }

            SetupNewDatabase(_dbContextOptions);
        }

        protected abstract void SetupNewDatabase(DbContextOptions<ApplicationContext> dbContextOptions);

        protected Responsible AddResponsible(ApplicationContext context, string code)
        {
            var responsible = new Responsible(TestPlant, code, $"{code}-Desc");
            context.Responsibles.Add(responsible);
            context.SaveChangesAsync().Wait();
            return responsible;
        }

        protected Person AddPerson(ApplicationContext context, Guid oid, string firstName, string lastName)
        {
            var person = new Person(oid, firstName, lastName);
            context.Persons.Add(person);
            context.SaveChangesAsync().Wait();
            return person;
        }

        protected Project AddProject(ApplicationContext context, string name, string description, bool isClosed = false)
        {
            var project = new Project(TestPlant, name, description);
            if (isClosed)
            {
                project.Close();
            }
            context.Projects.Add(project);
            context.SaveChangesAsync().Wait();
            return project;
        }
    }
}
