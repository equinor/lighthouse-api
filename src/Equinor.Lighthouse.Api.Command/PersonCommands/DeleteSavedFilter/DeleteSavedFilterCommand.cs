using System;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Command.PersonCommands.DeleteSavedFilter
{
    public class DeleteSavedFilterCommand : IRequest<Result<Unit>>
    {
        public DeleteSavedFilterCommand(Guid savedFilterId, string? rowVersion)
        {
            SavedFilterId = savedFilterId;
            RowVersion = rowVersion;
        }

        public Guid SavedFilterId { get; }
        public string? RowVersion { get; }
    }
}
