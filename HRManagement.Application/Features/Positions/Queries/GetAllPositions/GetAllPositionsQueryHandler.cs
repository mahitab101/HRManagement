using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings.Positions;
using HRManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Positions.Queries.GetAllPositions
{
    public class GetAllPositionsQueryHandler : IRequestHandler<GetAllPositionsQuery, BaseResponse<List<PositionListVm>>>
    {
        private readonly IPositionRepository _positionRepository;

        public GetAllPositionsQueryHandler(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<BaseResponse<List<PositionListVm>>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
        {
            var positions = await _positionRepository.GetAllWithDepartmentAsync();
            var response = positions.ToPositionListVms();

            return BaseResponse<List<PositionListVm>>.SuccessResponse(response, "Positions retrieved successfully");
        }
    }
}
