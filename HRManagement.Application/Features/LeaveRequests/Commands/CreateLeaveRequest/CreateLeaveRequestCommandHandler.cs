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

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<BaseResponse<CreateLeaveRequestCommandResponse>> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = request.ToEntity();
            leaveRequest.Status = LeaveStatus.Pending;

            var created = await _leaveRequestRepository.AddAsync(leaveRequest);

            var response = new CreateLeaveRequestCommandResponse { Id = created.Id };

            return BaseResponse<CreateLeaveRequestCommandResponse>.SuccessResponse(response, "Leave request submitted successfully");
        }
    }
}
