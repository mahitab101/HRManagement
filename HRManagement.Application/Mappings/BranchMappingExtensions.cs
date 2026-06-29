using HRManagement.Application.Features.Branch.Commands.CreateBranch;
using HRManagement.Application.Features.Branch.Queries.GetAllBranches;
using HRManagement.Application.Features.Branch.Queries.GetBranchByDetails;
using HRManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Mappings
{
    public static class BranchMappingExtensions
    {
        public static Branch ToEntity(this CreateBranchCommand command)
        {
            return new Branch
            {
                Name = command.Name,
                Location = command.Location,
                ManagerId = command.ManagerId
            };
        }

        public static BranchListVm ToBranchListVm(this Branch branch)
        {
            return new BranchListVm
            {
                Id = branch.Id,
                Name = branch.Name,
                Location = branch.Location,
                ManagerId = branch.ManagerId,
                ManagerName = branch.Manager != null
                    ? $"{branch.Manager.FirstName} {branch.Manager.LastName}"
                    : null,
                EmployeesCount = branch.Employees?.Count ?? 0
            };
        }
 
            public static BranchDetailsVm ToBranchDetailsVm(this Branch branch)
            {
                return new BranchDetailsVm
                {
                    Id = branch.Id,
                    Name = branch.Name,
                    Location = branch.Location,
                    ManagerId = branch.ManagerId,
                    ManagerName = branch.Manager != null
                        ? $"{branch.Manager.FirstName} {branch.Manager.LastName}"
                        : null,
                    EmployeesCount = branch.Employees?.Count ?? 0,
                    Employees = branch.Employees?
                        .Select(e => new EmployeeSummaryVm
                        {
                            Id = e.Id,
                            FirstName = e.FirstName,
                            LastName = e.LastName
                        }).ToList() ?? new List<EmployeeSummaryVm>()
                };
            }
        }
    }

