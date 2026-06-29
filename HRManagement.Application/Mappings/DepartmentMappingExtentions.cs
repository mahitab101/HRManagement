using HRManagement.Application.Features.Departments.Commands.CreateDepartment;
using HRManagement.Application.Features.Departments.Queries.GetAllDepartments;
using HRManagement.Application.Features.Departments.Queries.GetDepartmentById;
using HRManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Mappings
{
    public static class DepartmentMappingExtentions
    {
        public static Department ToEntity(this CreateDepartmentCommand command)
        {
            return new Department
            {
                Name = command.Name,
                ManagerId = command.ManagerId
            };
        }

        public static DepartmentListVm ToDepartmentListVms(this Department department)
        {
            return new DepartmentListVm
            {
                Id = department.Id,
                Name = department.Name,
                ManagerId = department.ManagerId,
                ManagerName = department.Manager != null
                ? $"{department.Manager.FirstName} {department.Manager.LastName}"
                : null,
                EmployeesCount = department.Employees?.Count ?? 0
            };

        }

        public static DepartmentDetailsVm ToDepartmentDetailsVm(this Department department)
        {
            return new DepartmentDetailsVm
            {
                Id = department.Id,
                Name = department.Name,
                ManagerId = department.ManagerId,
                ManagerName = department.Manager != null
                    ? $"{department.Manager.FirstName} {department.Manager.LastName}"
                    : null,
                EmployeesCount = department.Employees?.Count ?? 0,
                Employees = department.Employees?
                    .Select(e => new EmployeeSummaryDto
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        PositionTitle = e.Position?.Title
                    }).ToList() ?? new List<EmployeeSummaryDto>()
            };
        }
    }
}
