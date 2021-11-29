using System;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Command.PersonCommands.UpdateSavedFilter;

public class UpdateSavedFilterCommand : IRequest<Result<string>>
{
    public UpdateSavedFilterCommand(
        Guid savedFilterId,
        string? title,
        string? criteria,
        bool? defaultFilter,
        string rowVersion)
    {
        SavedFilterId = savedFilterId;
        Title = title;
        Criteria = criteria;
        DefaultFilter = defaultFilter;
        RowVersion = rowVersion;
    }

    public Guid SavedFilterId { get; }
    public string? Title { get; }
    public string? Criteria { get; }
    public bool? DefaultFilter { get; }
    public string RowVersion { get; }
}
