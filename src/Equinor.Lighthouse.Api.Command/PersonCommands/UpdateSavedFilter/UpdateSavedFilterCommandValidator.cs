using System;
using System.Threading;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Command.Validators;
using Equinor.Lighthouse.Api.Command.Validators.SavedFilterValidators;
using FluentValidation;

namespace Equinor.Lighthouse.Api.Command.PersonCommands.UpdateSavedFilter;

public class UpdateSavedFilterCommandValidator : AbstractValidator<UpdateSavedFilterCommand>
{
    public UpdateSavedFilterCommandValidator(
        ISavedFilterValidator savedFilterValidator,
        IRowVersionValidator rowVersionValidator)
    {
        CascadeMode = CascadeMode.Stop;

        RuleFor(command => command)
            .MustAsync((command, token) => BeAnExistingSavedFilterAsync(command.SavedFilterId, token))
            .WithMessage(command => $"Saved filter doesn't exist! Saved filter={command.SavedFilterId}")
            .MustAsync((command, token) => HaveAUniqueTitleForPerson(command.Title, command.SavedFilterId, token))
            .WithMessage(command => $"A saved filter with this title already exists! Title={command.Title}")
            .Must(command => HaveAValidRowVersion(command.RowVersion))
            .WithMessage(command => $"Not a valid row version! Row version={command.RowVersion}");

        async Task<bool> BeAnExistingSavedFilterAsync(Guid savedFilterId, CancellationToken token)
            => await savedFilterValidator.ExistsAsync(savedFilterId, token);
        async Task<bool> HaveAUniqueTitleForPerson(string? title, Guid savedFilterId, CancellationToken token)
            => !await savedFilterValidator.ExistsAnotherWithSameTitleForPersonInProjectAsync(savedFilterId, title, token);
        bool HaveAValidRowVersion(string rowVersion)
            => rowVersionValidator.IsValid(rowVersion);
    }
}