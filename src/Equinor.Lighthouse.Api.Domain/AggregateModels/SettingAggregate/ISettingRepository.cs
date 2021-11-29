using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.Domain.AggregateModels.SettingAggregate
{
    public interface ISettingRepository : IRepository<Setting>
    {
        Task<Setting> GetByCodeAsync(string settingCode);
    }
}
