using HRManagement.Application.Responses;
using MediatR;

namespace HRManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommand : IRequest<BaseResponse<CreateLeaveTypeCommandResponse>>
    {
        public string Name { get; set; } = string.Empty;
        public int MaxDaysPerYear { get; set; }
        public bool AllowCarryOver { get; set; }
        public int? MaxCarryOverDays { get; set; }
    }
}
