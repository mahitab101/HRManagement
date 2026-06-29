using HRManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace HRManagement.Application.Features.Positions.Queries.GetAllPositions
{
    public class GetAllPositionsQuery : IRequest<BaseResponse<List<PositionListVm>>>
    {
    }
}
