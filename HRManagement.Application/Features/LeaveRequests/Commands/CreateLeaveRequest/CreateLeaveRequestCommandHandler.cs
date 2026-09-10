using HRManagement.Application.Contracts;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings.LeaveRequests;
using HRManagement.Application.Responses;
using HRManagement.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveRequests.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseResponse<CreateLeaveRequestCommandResponse>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveBalanceService _leaveBalanceService;
        private readonly IWorkingDaysCalculator _workingDaysCalculator;

        public CreateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            ILeaveBalanceService leaveBalanceService,
            IWorkingDaysCalculator workingDaysCalculator)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveBalanceService = leaveBalanceService;
            _workingDaysCalculator = workingDaysCalculator;
        }

        public async Task<BaseResponse<CreateLeaveRequestCommandResponse>> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var hasOverlap = await _leaveRequestRepository.HasOverlappingRequestAsync(
                request.EmployeeId, request.StartDate, request.EndDate);

            if (hasOverlap)
                return BaseResponse<CreateLeaveRequestCommandResponse>.FailureResponse(
                    "You already have a leave request that overlaps with these dates.");

            var requestedDays = await _workingDaysCalculator.CalculateWorkingDaysAsync(
                request.EmployeeId, request.StartDate, request.EndDate);

            if (requestedDays <= 0)
                return BaseResponse<CreateLeaveRequestCommandResponse>.FailureResponse(
                    "The selected period doesn't contain any working days.");

            var year = request.StartDate.Year;

            var hasSufficientBalance = await _leaveBalanceService.HasSufficientBalanceAsync(
                request.EmployeeId, request.LeaveTypeId, requestedDays, year);

            if (!hasSufficientBalance)
                return BaseResponse<CreateLeaveRequestCommandResponse>.FailureResponse(
                    "Insufficient leave balance for the requested period.");

            await _leaveBalanceService.HoldBalanceAsync(
                request.EmployeeId, request.LeaveTypeId, requestedDays, year);

            var leaveRequest = request.ToEntity();
            leaveRequest.Status = LeaveStatus.Pending;
            leaveRequest.RequestedDays = requestedDays;

            var created = await _leaveRequestRepository.AddAsync(leaveRequest);

            var response = new CreateLeaveRequestCommandResponse { Id = created.Id };

            return BaseResponse<CreateLeaveRequestCommandResponse>.SuccessResponse(response, "Leave request submitted successfully");
        }
    }
}