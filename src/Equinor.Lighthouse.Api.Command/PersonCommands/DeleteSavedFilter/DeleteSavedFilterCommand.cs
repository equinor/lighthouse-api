﻿using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Command.PersonCommands.DeleteSavedFilter
{
    public class DeleteSavedFilterCommand : IRequest<Result<Unit>>
    {
        public DeleteSavedFilterCommand(int savedFilterId, string rowVersion)
        {
            SavedFilterId = savedFilterId;
            RowVersion = rowVersion;
        }

        public int SavedFilterId { get; }
        public string RowVersion { get; }
    }
}
