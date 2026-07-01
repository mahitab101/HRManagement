using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Responses;
using HRManagement.Domain.Enums; 
using MediatR;

namespace HRManagement.Application.Features.Dashboard.Queries.GetDashboardStats
{
    public class GetDashboardStatsQueryHandler
        : IRequestHandler<GetDashboardStatsQuery, BaseResponse<DashboardStatsResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public GetDashboardStatsQueryHandler(
            IEmployeeRepository employeeRepository,
            IBranchRepository branchRepository,
            IDepartmentRepository departmentRepository,
            ILeaveRequestRepository leaveRequestRepository)
        {
            _employeeRepository = employeeRepository;
            _branchRepository = branchRepository;
            _departmentRepository = departmentRepository;
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<BaseResponse<DashboardStatsResponse>> Handle(
            GetDashboardStatsQuery request,
            CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsync();
            var branches = await _branchRepository.GetAllAsync();
            var departments = await _departmentRepository.GetAllAsync();
            var leaveRequests = await _leaveRequestRepository.GetAllAsync();

            var response = new DashboardStatsResponse
            {
                TotalEmployees = employees.Count(),
                TotalBranches = branches.Count(),
                TotalDepartments = departments.Count(),
                PendingLeaveRequests = leaveRequests.Count(lr => lr.Status == LeaveStatus.Pending)
            };

            return BaseResponse<DashboardStatsResponse>.SuccessResponse(response, "Dashboard stats retrieved successfully.");
        }
    }
}