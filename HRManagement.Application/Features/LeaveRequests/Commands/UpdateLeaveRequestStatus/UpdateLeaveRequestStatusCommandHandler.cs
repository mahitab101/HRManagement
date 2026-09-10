using HRManagement.Application.Contracts;
using HRManagement.Application.Contracts.Identity;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Responses;
using HRManagement.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveRequests.Commands.UpdateLeaveRequestStatus
{
    public class UpdateLeaveRequestStatusCommandHandler : IRequestHandler<UpdateLeaveRequestStatusCommand, BaseResponse<bool>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILeaveBalanceService _leaveBalanceService;

        public UpdateLeaveRequestStatusCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            ICurrentUserService currentUserService,
            ILeaveBalanceService leaveBalanceService)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _currentUserService = currentUserService;
            _leaveBalanceService = leaveBalanceService;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateLeaveRequestStatusCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequest == null)
                return BaseResponse<bool>.FailureResponse($"Leave request with Id {request.Id} not found");

            var year = leaveRequest.StartDate.Year;
            var days = leaveRequest.RequestedDays;
            var previousStatus = leaveRequest.Status;

            if (request.Status == LeaveStatus.Approved && previousStatus == LeaveStatus.Pending)
            {
                await _leaveBalanceService.ConfirmBalanceAsync(
                    leaveRequest.EmployeeId, leaveRequest.LeaveTypeId, days, year);
            }
            else if (request.Status == LeaveStatus.Rejected && previousStatus == LeaveStatus.Pending)
            {
                await _leaveBalanceService.ReleaseHoldAsync(
                    leaveRequest.EmployeeId, leaveRequest.LeaveTypeId, days, year);
            }
            else if (request.Status == LeaveStatus.Rejected && previousStatus == LeaveStatus.Approved)
            {
                await _leaveBalanceService.RestoreBalanceAsync(
                    leaveRequest.EmployeeId, leaveRequest.LeaveTypeId, days, year);
            }

            leaveRequest.Status = request.Status;
            leaveRequest.ApproverId = _currentUserService.EmployeeId;

            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            return BaseResponse<bool>.SuccessResponse(true, "Leave request status updated successfully");
        }
    }
}