using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveRequests.Commands.UpdateLeaveRequestStatus
{
    public class UpdateLeaveRequestStatusCommandHandler : IRequestHandler<UpdateLeaveRequestStatusCommand, BaseResponse<bool>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UpdateLeaveRequestStatusCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateLeaveRequestStatusCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequest == null)
                return BaseResponse<bool>.FailureResponse($"Leave request with Id {request.Id} not found");

            leaveRequest.Status = request.Status;
            leaveRequest.ApproverId = request.ApproverId;

            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            return BaseResponse<bool>.SuccessResponse(true, "Leave request status updated successfully");
        }
    }
}
