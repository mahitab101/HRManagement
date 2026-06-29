using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings.LeaveRequests;
using HRManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveRequests.Queries.GetAllLeaveRequests
{
    public class GetAllLeaveRequestsQueryHandler : IRequestHandler<GetAllLeaveRequestsQuery, BaseResponse<List<LeaveRequestListVm>>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public GetAllLeaveRequestsQueryHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<BaseResponse<List<LeaveRequestListVm>>> Handle(GetAllLeaveRequestsQuery request, CancellationToken cancellationToken)
        {
            var leaveRequests = await _leaveRequestRepository.GetAllWithDetailsAsync();
            var response = leaveRequests.ToLeaveRequestListVms();

            return BaseResponse<List<LeaveRequestListVm>>.SuccessResponse(response, "Leave requests retrieved successfully");
        }
    }
}
