using System;
using System.Collections.Generic;
using System.Linq;
using Equinor.Lighthouse.Api.Domain.Audit;
using Equinor.Lighthouse.Api.Domain.Time;

namespace Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;

public class Person : EntityBase, IAggregateRoot, IModificationAuditable
{
    public const int FirstNameLengthMax = 64;
    public const int LastNameLengthMax = 64;

    private readonly List<SavedFilter?> _savedFilters = new();

    protected Person()
    {
    }

    public Person(Guid oid, string? firstName, string? lastName) : base()
    {
        Oid = oid;
        FirstName = firstName;
        LastName = lastName;
    }

    public IReadOnlyCollection<SavedFilter?> SavedFilters => _savedFilters.AsReadOnly();
    public Guid Oid { get; private set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? ModifiedAtUtc { get; private set; }
    public Guid? ModifiedById { get; private set; }

    public void SetModified(Person modifiedBy)
    {
        ModifiedAtUtc = TimeService.UtcNow;
        if (modifiedBy == null)
        {
            throw new ArgumentNullException(nameof(modifiedBy));
        }
        ModifiedById = modifiedBy.Id;
    }

    public void AddSavedFilter(SavedFilter? savedFilter)
    {
        if (savedFilter == null)
        {
            throw new ArgumentNullException(nameof(savedFilter));
        }

        _savedFilters.Add(savedFilter);
    }

    public void RemoveSavedFilter(SavedFilter? savedFilter)
    {
        if (savedFilter == null)
        {
            throw new ArgumentNullException(nameof(savedFilter));
        }

        _savedFilters.Remove(savedFilter);
    }

    public SavedFilter? GetDefaultFilter(Guid? projectId) =>
        _savedFilters.SingleOrDefault(s => s.ProjectId == projectId && s.DefaultFilter);
}
