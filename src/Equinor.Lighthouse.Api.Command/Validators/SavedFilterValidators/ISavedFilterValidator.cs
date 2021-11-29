using System.Threading;
using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.Command.Validators.SavedFilterValidators
{
    public interface ISavedFilterValidator
    {
        Task<bool> ExistsWithSameTitleForPersonInProjectAsync(string title, string projectName, CancellationToken cancellationToken);
        Task<bool> ExistsAnotherWithSameTitleForPersonInProjectAsync(int savedFilterId, string title, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(int savedFilterId, CancellationToken token);
    }
}
