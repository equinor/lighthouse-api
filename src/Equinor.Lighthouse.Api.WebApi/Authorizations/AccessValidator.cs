using System;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Equinor.Lighthouse.Api.WebApi.Authorizations
{
    public class AccessValidator : IAccessValidator
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IProjectAccessChecker _projectAccessChecker;
        private readonly IContentRestrictionsChecker _contentRestrictionsChecker;
        private readonly ILogger<AccessValidator> _logger;

        public AccessValidator(
            ICurrentUserProvider currentUserProvider, 
            IProjectAccessChecker projectAccessChecker,
            IContentRestrictionsChecker contentRestrictionsChecker,
            ILogger<AccessValidator> logger)
        {
            _currentUserProvider = currentUserProvider;
            _projectAccessChecker = projectAccessChecker;
            _contentRestrictionsChecker = contentRestrictionsChecker;
            _logger = logger;
        }

        public async Task<bool> ValidateAsync<TRequest>(TRequest request) where TRequest : IBaseRequest
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var userOid = _currentUserProvider.GetCurrentUserOid();
            if (request is IProjectRequest projectRequest && !_projectAccessChecker.HasCurrentUserAccessToProject(projectRequest.ProjectName))
            {
                _logger.LogWarning($"Current user {userOid} doesn't have have access to project {projectRequest.ProjectName}");
                return false;
            }

            return true;
        }
    }
}
