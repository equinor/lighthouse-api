using System;
using System.Threading;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Command.PersonCommands.CreateSavedFilter;

public class CreateSavedFilterCommandHandler : IRequestHandler<CreateSavedFilterCommand, Result<Guid>>
{
    private readonly IPersonRepository _personRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlantProvider _plantProvider;
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly IProjectRepository _projectRepository;

    public CreateSavedFilterCommandHandler(
        IPersonRepository personRepository,
        IUnitOfWork unitOfWork,
        IPlantProvider plantProvider,
        ICurrentUserProvider currentUserProvider,
        IProjectRepository projectRepository)
    {
        _personRepository = personRepository;
        _unitOfWork = unitOfWork;
        _plantProvider = plantProvider;
        _currentUserProvider = currentUserProvider;
        _projectRepository = projectRepository;
    }

    public async Task<Result<Guid>> Handle(CreateSavedFilterCommand request, CancellationToken cancellationToken)
    {
        var currentUserOid = _currentUserProvider.GetCurrentUserOid();
        var person = await _personRepository.GetWithSavedFiltersByOidAsync(currentUserOid);
        var project = await _projectRepository.GetProjectOnlyByNameAsync(request.ProjectName);

        if (request.DefaultFilter)
        {
            var currentDefaultFilter = person.GetDefaultFilter(project.Id);

            if (currentDefaultFilter != null)
            {
                currentDefaultFilter.DefaultFilter = false;
            }
        }

        var savedFilter = new SavedFilter(_plantProvider.Plant, project, request.Title, request.Criteria)
        {
            DefaultFilter = request.DefaultFilter
        };

        person.AddSavedFilter(savedFilter);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new SuccessResult<Guid>(savedFilter.Id);
    }
}