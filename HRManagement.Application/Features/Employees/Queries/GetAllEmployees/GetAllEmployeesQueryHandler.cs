using HRManagement.Application.Common;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings;
using HRManagement.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, BaseResponse<PaginatedList<EmployeeListVm>>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<BaseResponse<PaginatedList<EmployeeListVm>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var (employees, totalCount) = await _employeeRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            var items = employees.ToEmployeeListVms();

            var paginatedResult = new PaginatedList<EmployeeListVm>(items, totalCount, request.PageNumber, request.PageSize);

            return BaseResponse<PaginatedList<EmployeeListVm>>.SuccessResponse(paginatedResult, "Employees retrieved successfully");
        }
    }
}