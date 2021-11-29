using System;
using System.Collections.Generic;
using System.Linq;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Equinor.Lighthouse.Api.Domain.Audit;
using Equinor.Lighthouse.Api.Domain.Time;

namespace Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate
{
    public class Project : PlantEntityBase, IAggregateRoot, ICreationAuditable, IModificationAuditable
    {
        public const int NameLengthMax = 30;
        public const int DescriptionLengthMax = 1000;

        protected Project()
            : base(null)
        {
        }

        public Project(string plant, string name, string description)
            : base(plant)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; set; }
        public bool IsClosed { get; set; }
        public DateTime CreatedAtUtc { get; private set; }
        public Guid? CreatedById { get; private set; }
        public DateTime? ModifiedAtUtc { get; private set; }
        public Guid? ModifiedById { get; private set; }


        public void Close() => IsClosed = true;

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
    }
}
