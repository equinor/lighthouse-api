using System;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Command.PersonCommands.CreateSavedFilter
{
    public class CreateSavedFilterCommand : IRequest<Result<Guid>>
    {
        public CreateSavedFilterCommand(
            string projectName,
            string? title,
            string? criteria,
            bool defaultFilter)
        {
            ProjectName = projectName;
            Title = title;
            Criteria = criteria;
            DefaultFilter = defaultFilter;
        }

        public string ProjectName { get; }
        public string? Title { get; }
        public string? Criteria { get; }
        public bool DefaultFilter { get; }
    }
}
