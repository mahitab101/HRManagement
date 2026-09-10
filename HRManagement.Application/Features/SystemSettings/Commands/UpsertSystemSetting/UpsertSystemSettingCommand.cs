using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace HRManagement.Application.Features.SystemSettings.Commands.UpsertSystemSetting
{
    public class UpsertSystemSettingCommand : IRequest<BaseResponse<bool>>
    {
        public Guid? BranchId { get; set; }
        public List<DayOfWeek> WeekendDays { get; set; } = new();
        public decimal WorkingHoursPerDay { get; set; }
    }
}