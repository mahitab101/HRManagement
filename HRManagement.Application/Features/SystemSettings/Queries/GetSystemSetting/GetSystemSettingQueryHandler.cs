// GetSystemSettingQueryHandler.cs
using HRManagement.Application.Contracts;
using HRManagement.Application.Responses;
using MediatR;

namespace HRManagement.Application.Features.SystemSettings.Queries.GetSystemSetting
{
    public class GetSystemSettingQueryHandler : IRequestHandler<GetSystemSettingQuery, BaseResponse<SystemSettingVm>>
    {
        private readonly ISystemSettingService _systemSettingService;

        public GetSystemSettingQueryHandler(ISystemSettingService systemSettingService)
        {
            _systemSettingService = systemSettingService;
        }

        public async Task<BaseResponse<SystemSettingVm>> Handle(GetSystemSettingQuery request, CancellationToken cancellationToken)
        {
            var settings = request.BranchId.HasValue
                ? await _systemSettingService.GetSettingsForBranchAsync(request.BranchId.Value)
                : await _systemSettingService.GetGlobalSettingsAsync();

            var vm = new SystemSettingVm
            {
                BranchId = settings.BranchId,
                WeekendDays = settings.WeekendDays,
                WorkingHoursPerDay = settings.WorkingHoursPerDay
            };

            return BaseResponse<SystemSettingVm>.SuccessResponse(vm, "Settings retrieved successfully");
        }
    }
}