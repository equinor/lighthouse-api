using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.Command.Validators.ProjectValidators
{
    public interface IProjectValidator
    {
        Task<bool> ExistsAsync(string projectName, CancellationToken token);
        
        Task<bool> IsExistingAndClosedAsync(string projectName, CancellationToken token);
    }
}
