
using HRManagement.Application.Responses;
using HRManagement.Domain.Entities;
using MediatR;
using System;

namespace HRManagement.Application.Features.SystemSettings.Queries.GetSystemSetting
{
    public class GetSystemSettingQuery : IRequest<BaseResponse<SystemSettingVm>>
    {
        public Guid? BranchId { get; set; }   
    }
}