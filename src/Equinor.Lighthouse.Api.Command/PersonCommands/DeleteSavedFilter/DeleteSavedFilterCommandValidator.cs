using System;
using System.Threading;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Command.Validators;
using Equinor.Lighthouse.Api.Command.Validators.SavedFilterValidators;
using FluentValidation;

namespace Equinor.Lighthouse.Api.Command.PersonCommands.DeleteSavedFilter;

public class DeleteSavedFilterCommandValidator : AbstractValidator<DeleteSavedFilterCommand>
{
    public DeleteSavedFilterCommandValidator(
        ISavedFilterValidator savedFilterValidator,
        IRowVersionValidator rowVersionValidator)
    {
        CascadeMode = CascadeMode.Stop;

        RuleFor(command => command)
            .MustAsync((command, token) => BeAnExistingSavedFilterAsync(command.SavedFilterId, token))
            .WithMessage(command => $"Saved filter doesn't exist! Saved filter={command.SavedFilterId}")
            .Must(command => HaveAValidRowVersion(command.RowVersion))
            .WithMessage(command => $"Not a valid row version! Row version={command.RowVersion}");

        async Task<bool> BeAnExistingSavedFilterAsync(Guid savedFilterId, CancellationToken token)
            => await savedFilterValidator.ExistsAsync(savedFilterId, token);

        bool HaveAValidRowVersion(string rowVersion)
            => rowVersionValidator.IsValid(rowVersion);
    }
}
