using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace Equinor.Lighthouse.Api.Infrastructure
{
    public class CommonDbContext : DbContext
        {
            protected readonly IPlantProvider _plantProvider;
            protected readonly IEventDispatcher _eventDispatcher;
            protected readonly ICurrentUserProvider _currentUserProvider;

        
            public CommonDbContext(
                DbContextOptions<CommonDbContext> options,
                IPlantProvider plantProvider,
                IEventDispatcher eventDispatcher,
                ICurrentUserProvider currentUserProvider)
                : base(options)
            {
                _plantProvider = plantProvider;
                _eventDispatcher = eventDispatcher;
                _currentUserProvider = currentUserProvider;
            }






    }
}
