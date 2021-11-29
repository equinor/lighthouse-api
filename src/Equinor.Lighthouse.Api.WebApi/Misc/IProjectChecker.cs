using System.Threading.Tasks;
using MediatR;

namespace Equinor.Lighthouse.Api.WebApi.Misc;

public interface IProjectChecker
{
    Task EnsureValidProjectAsync<TRequest>(TRequest request) where TRequest: IBaseRequest;
}