using System.Threading;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.SettingAggregate;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Command.MiscCommands.UpdateDateTimeSetting
{
    public class UpdateDateTimeSettingCommandHandler : IRequestHandler<UpdateDateTimeSettingCommand, Result<Unit>>
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlantProvider _plantProvider;

        public UpdateDateTimeSettingCommandHandler(ISettingRepository settingRepository, IUnitOfWork unitOfWork, IPlantProvider plantProvider)
        {
            _settingRepository = settingRepository;
            _unitOfWork = unitOfWork;
            _plantProvider = plantProvider;
        }

        public async Task<Result<Unit>> Handle(UpdateDateTimeSettingCommand request, CancellationToken cancellationToken)
        {
            var setting = await _settingRepository.GetByCodeAsync(request.SettingCode);

            if (setting == null)
            {
                setting = new Setting(_plantProvider.Plant, request.SettingCode);
                _settingRepository.Add(setting);
            }

            setting.SetDateTime(request.Value);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new SuccessResult<Unit>(Unit.Value);
        }
    }
}
