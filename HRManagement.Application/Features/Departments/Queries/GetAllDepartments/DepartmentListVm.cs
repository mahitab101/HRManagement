namespace HRManagement.Application.Features.Departments.Queries.GetAllDepartments
{
    public class DepartmentListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ManagerId { get; set; }
        public string? ManagerName { get; set; }
        public int EmployeesCount { get; set; }
    }
}