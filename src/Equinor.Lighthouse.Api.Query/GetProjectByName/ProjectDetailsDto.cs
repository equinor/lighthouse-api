using System;

namespace Equinor.Lighthouse.Api.Query.GetProjectByName;

public class ProjectDetailsDto
{
    public ProjectDetailsDto(Guid id, string name, string description, bool isClosed)
    {
        Id = id;
        Name = name;
        Description = description;
        IsClosed = isClosed;
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public bool IsClosed { get; }
}