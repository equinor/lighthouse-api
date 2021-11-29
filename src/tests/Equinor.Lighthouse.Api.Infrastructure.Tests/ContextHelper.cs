using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Equinor.Lighthouse.Api.Infrastructure.Tests
{
    public class ContextHelper
    {
        public ContextHelper()
        {
            DbOptions = new DbContextOptions<ApplicationContext>();
            EventDispatcherMock = new Mock<IEventDispatcher>();
            PlantProviderMock = new Mock<IPlantProvider>();
            CurrentUserProviderMock = new Mock<ICurrentUserProvider>();
            ContextMock = new Mock<ApplicationContext>(DbOptions, PlantProviderMock.Object, EventDispatcherMock.Object, CurrentUserProviderMock.Object);
        }

        public DbContextOptions<ApplicationContext> DbOptions { get; }
        public Mock<IEventDispatcher> EventDispatcherMock { get; }
        public Mock<IPlantProvider> PlantProviderMock { get; }
        public Mock<ApplicationContext> ContextMock { get; }
        public Mock<ICurrentUserProvider> CurrentUserProviderMock { get; }
    }
}
