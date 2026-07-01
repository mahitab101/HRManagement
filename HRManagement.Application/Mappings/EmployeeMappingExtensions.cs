using HRManagement.Application.Features.Employees.Commands.CreateEmployee;
using HRManagement.Application.Features.Employees.Queries.GetAllEmployees;
using HRManagement.Application.Features.Employees.Queries.GetEmployeeById;
using HRManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Mappings
{
    public static class EmployeeMappingExtensions
    {
        public static EmployeeDetailsVm ToEmployeeDetailsVm(this Employee employee)
        {
            return new EmployeeDetailsVm
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Phone = employee.Phone,
                Gender = employee.Gender,
                HireDate = employee.HireDate,
                Status = employee.Status,
                NationalId = employee.NationalId,       
                DateOfBirth = employee.DateOfBirth,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department?.Name,
                PositionId = employee.PositionId,
                PositionName = employee.Position?.Title,
                BranchId = employee.BranchId,
                BranchName = employee.Branch?.Name
            };
        }

        public static EmployeeListVm ToEmployeeListVm(this Employee employee)
        {
            return new EmployeeListVm
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Phone = employee.Phone,
                Gender = employee.Gender,
                HireDate = employee.HireDate,
                Status = employee.Status,
                HasAccount = false,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department?.Name,
                PositionId = employee.PositionId,
                PositionName = employee.Position?.Title,
                BranchId = employee.BranchId,
                BranchName = employee.Branch?.Name
            };
        }

        public static List<EmployeeListVm> ToEmployeeListVms(this IEnumerable<Employee> employees)
        {
            return employees.Select(e => e.ToEmployeeListVm()).ToList();
        }
        public static Employee ToEntity(this CreateEmployeeCommand command)
        {
            return new Employee
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Phone = command.Phone,
                NationalId = command.NationalId,
                Gender = command.Gender,
                DateOfBirth = command.DateOfBirth,
                HireDate = command.HireDate,
                Status = command.Status,
                DepartmentId = command.DepartmentId,
                PositionId = command.PositionId,
                BranchId = command.BranchId
            };
        }
    }
}
