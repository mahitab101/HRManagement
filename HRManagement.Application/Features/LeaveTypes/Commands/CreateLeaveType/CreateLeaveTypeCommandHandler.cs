using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings.LeaveTypes;
using HRManagement.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseResponse<CreateLeaveTypeCommandResponse>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<BaseResponse<CreateLeaveTypeCommandResponse>> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = request.ToEntity();
            var created = await _leaveTypeRepository.AddAsync(leaveType);

            var response = new CreateLeaveTypeCommandResponse { Id = created.Id };

            return BaseResponse<CreateLeaveTypeCommandResponse>.SuccessResponse(response, "Leave type created successfully");
        }
    }
}
