using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain.AggregateModels.SettingAggregate;
using Microsoft.EntityFrameworkCore;

namespace Equinor.Lighthouse.Api.Infrastructure.Repositories
{
    public class SettingRepository : RepositoryBase<Setting>, ISettingRepository
    {
        public SettingRepository(ApplicationContext context) : base(context, context.Settings)
        {
        }
        
        public Task<Setting?> GetByCodeAsync(string settingCode) 
            => DefaultQuery.SingleOrDefaultAsync(r => r.Code == settingCode);
    }
}
