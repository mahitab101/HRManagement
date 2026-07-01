namespace HRManagement.Application.Features.Dashboard.Queries.GetDashboardStats
{
    public class DashboardStatsResponse
    {
        public int TotalEmployees { get; set; }
        public int TotalBranches { get; set; }
        public int TotalDepartments { get; set; }
        public int PendingLeaveRequests { get; set; }
    }
}