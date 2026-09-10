using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Responses;
using HRManagement.Domain.Entities;
using MediatR;

namespace HRManagement.Application.Features.SystemSettings.Commands.UpsertSystemSetting
{
    public class UpsertSystemSettingCommandHandler : IRequestHandler<UpsertSystemSettingCommand, BaseResponse<bool>>
    {
        private readonly ISystemSettingRepository _systemSettingRepository;

        public UpsertSystemSettingCommandHandler(ISystemSettingRepository systemSettingRepository)
        {
            _systemSettingRepository = systemSettingRepository;
        }

        public async Task<BaseResponse<bool>> Handle(UpsertSystemSettingCommand request, CancellationToken cancellationToken)
        {
            if (request.WeekendDays == null || request.WeekendDays.Count == 0)
                return BaseResponse<bool>.FailureResponse("At least one weekend day must be specified.");

            var existing = await _systemSettingRepository.GetByBranchIdAsync(request.BranchId);

            if (existing != null)
            {
                existing.WeekendDays = request.WeekendDays;
                existing.WorkingHoursPerDay = request.WorkingHoursPerDay;
                await _systemSettingRepository.UpdateAsync(existing);
            }
            else
            {
                await _systemSettingRepository.AddAsync(new SystemSetting
                {
                    BranchId = request.BranchId,
                    WeekendDays = request.WeekendDays,
                    WorkingHoursPerDay = request.WorkingHoursPerDay
                });
            }

            return BaseResponse<bool>.SuccessResponse(true, "Settings saved successfully");
        }
    }
}