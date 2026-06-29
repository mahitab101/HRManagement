using HRManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace HRManagement.Application.Features.LeaveRequests.Queries.GetAllLeaveRequests
{
    public class GetAllLeaveRequestsQuery : IRequest<BaseResponse<List<LeaveRequestListVm>>>
    {
    }
}
