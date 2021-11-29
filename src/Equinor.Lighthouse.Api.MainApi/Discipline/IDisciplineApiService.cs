using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.MainApi.Discipline;

public interface IDisciplineApiService
{
    Task<PCSDiscipline> TryGetDisciplineAsync(string plant, string code);
}