using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings.Positions;
using HRManagement.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, BaseResponse<CreatePositionCommandResponse>>
    {
        private readonly IPositionRepository _positionRepository;

        public CreatePositionCommandHandler(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<BaseResponse<CreatePositionCommandResponse>> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = request.ToEntity();
            var created = await _positionRepository.AddAsync(position);

            var response = new CreatePositionCommandResponse { Id = created.Id };

            return BaseResponse<CreatePositionCommandResponse>.SuccessResponse(response, "Position created successfully");
        }
    }
}
