using HRManagement.Application.Common;
using HRManagement.Application.Contracts.Identity;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Features.Employees.Queries.GetAllEmployees;
using HRManagement.Application.Mappings;
using HRManagement.Application.Responses;
using MediatR;

public class GetAllEmployeesQueryHandler
    : IRequestHandler<GetAllEmployeesQuery, BaseResponse<PaginatedList<EmployeeListVm>>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUserRepository _userRepository;

    public GetAllEmployeesQueryHandler(
        IEmployeeRepository employeeRepository,
        IUserRepository userRepository)
    {
        _employeeRepository = employeeRepository;
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<PaginatedList<EmployeeListVm>>> Handle(
        GetAllEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        var (employees, totalCount) = await _employeeRepository.GetPagedAsync(
            request.PageNumber, request.PageSize);

        var employeeIdsWithAccounts = await _userRepository.GetEmployeeIdsWithAccountsAsync();
        var accountSet = employeeIdsWithAccounts.ToHashSet();

        var items = employees.Select(e =>
        {
            var vm = e.ToEmployeeListVm();
            vm.HasAccount = accountSet.Contains(e.Id);
            return vm;
        }).ToList();

        var paginatedResult = new PaginatedList<EmployeeListVm>(
            items, totalCount, request.PageNumber, request.PageSize);

        return BaseResponse<PaginatedList<EmployeeListVm>>.SuccessResponse(
            paginatedResult, "Employees retrieved successfully");
    }
}