using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using FluentValidation;

namespace Equinor.Lighthouse.Api.WebApi.Controllers.Persons
{
    public class CreateSavedFilterDtoValidator : AbstractValidator<CreateSavedFilterDto>
    {
        public CreateSavedFilterDtoValidator()
        {
            RuleFor(x => x.ProjectName)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Title)
                .NotNull()
                .MaximumLength(SavedFilter.TitleLengthMax);
            RuleFor(x => x.Criteria)
                .NotNull()
                .MaximumLength(SavedFilter.CriteriaLengthMax);
        }
    }
}
