using HRManagement.Domain.Entities;

namespace HRManagement.Application.Features.Branch.Queries.GetAllBranches
{
    public class BranchListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Guid? ManagerId { get; set; }
        public string? ManagerName { get; set; } 
        public int EmployeesCount { get; set; }
    }
}