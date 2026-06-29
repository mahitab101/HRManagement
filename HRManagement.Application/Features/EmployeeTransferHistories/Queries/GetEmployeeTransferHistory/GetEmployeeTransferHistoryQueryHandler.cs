using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings.EmployeeTransferHistories;
using HRManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.EmployeeTransferHistories.Queries.GetEmployeeTransferHistory
{
    public class GetEmployeeTransferHistoryQueryHandler : IRequestHandler<GetEmployeeTransferHistoryQuery, BaseResponse<List<TransferHistoryListVm>>>
    {
        private readonly IEmployeeTransferHistoryRepository _transferHistoryRepository;

        public GetEmployeeTransferHistoryQueryHandler(IEmployeeTransferHistoryRepository transferHistoryRepository)
        {
            _transferHistoryRepository = transferHistoryRepository;
        }

        public async Task<BaseResponse<List<TransferHistoryListVm>>> Handle(GetEmployeeTransferHistoryQuery request, CancellationToken cancellationToken)
        {
            var history = await _transferHistoryRepository.GetByEmployeeIdAsync(request.EmployeeId);
            var response = history.ToTransferHistoryListVms();

            return BaseResponse<List<TransferHistoryListVm>>.SuccessResponse(response, "Transfer history retrieved successfully");
        }
    }
}
