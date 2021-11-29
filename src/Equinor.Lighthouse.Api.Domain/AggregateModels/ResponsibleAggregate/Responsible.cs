using System;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Equinor.Lighthouse.Api.Domain.Audit;
using Equinor.Lighthouse.Api.Domain.Time;

namespace Equinor.Lighthouse.Api.Domain.AggregateModels.ResponsibleAggregate;

public class Responsible : PlantEntityBase, IAggregateRoot, ICreationAuditable, IModificationAuditable, IVoidable
{
    public const int CodeLengthMax = 255;
    public const int DescriptionLengthMax = 255;

    protected Responsible()
        : base(null)
    {
    }

    public Responsible(string plant, string code, string description)
        : base(plant)
    {
        Code = code;
        Description = description;
    }

    public string Code { get; private set; }
    public string Description { get; set; }
    public bool IsVoided { get; set; }

    public DateTime CreatedAtUtc { get; private set; }
    public Guid? CreatedById { get; private set; }
    public DateTime? ModifiedAtUtc { get; private set; }
    public Guid? ModifiedById { get; private set; }

    public void SetCreated(Person createdBy)
    {
        CreatedAtUtc = TimeService.UtcNow;
        if (createdBy == null)
        {
            throw new ArgumentNullException(nameof(createdBy));
        }
        CreatedById = createdBy.Id;
    }

    public void SetModified(Person modifiedBy)
    {
        ModifiedAtUtc = TimeService.UtcNow;
        if (modifiedBy == null)
        {
            throw new ArgumentNullException(nameof(modifiedBy));
        }
        ModifiedById = modifiedBy.Id;
    }

    public void RenameResponsible(string newCode)
    {
        if (string.IsNullOrWhiteSpace(newCode))
        {
            throw new ArgumentNullException(nameof(newCode));
        }

        Code = newCode;
    }
}
