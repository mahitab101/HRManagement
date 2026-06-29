using HRManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace HRManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes
{
    public class GetAllLeaveTypesQuery : IRequest<BaseResponse<List<LeaveTypeListVm>>>
    {
    }
}
