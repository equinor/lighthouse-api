using System;

namespace Equinor.Lighthouse.Api.Query.ResponsibleAggregate;

public class ResponsibleDto
{
    public ResponsibleDto(Guid id, string code, string description, string rowVersion)
    {
        Id = id;
        Code = code;
        Description = description;
        RowVersion = rowVersion;
    }

    public Guid Id { get; }
    public string Code { get; }
    public string Description { get; }
    public string RowVersion { get; }
}