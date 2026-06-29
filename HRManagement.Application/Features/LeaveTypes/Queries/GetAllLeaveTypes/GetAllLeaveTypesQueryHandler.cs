using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings.LeaveTypes;
using HRManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes
{
    public class GetAllLeaveTypesQueryHandler : IRequestHandler<GetAllLeaveTypesQuery, BaseResponse<List<LeaveTypeListVm>>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetAllLeaveTypesQueryHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<BaseResponse<List<LeaveTypeListVm>>> Handle(GetAllLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();
            var response = leaveTypes.ToLeaveTypeListVms();

            return BaseResponse<List<LeaveTypeListVm>>.SuccessResponse(response, "Leave types retrieved successfully");
        }
    }
}
