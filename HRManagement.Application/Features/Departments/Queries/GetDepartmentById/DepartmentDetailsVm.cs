using HRManagement.Domain.Entities;

namespace HRManagement.Application.Features.Departments.Queries.GetDepartmentById
{
    public class DepartmentDetailsVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ManagerId { get; set; }
        public string? ManagerName { get; set; } 
        public int EmployeesCount { get; set; }
        public ICollection<EmployeeSummaryDto> Employees { get; set; }
    }
}