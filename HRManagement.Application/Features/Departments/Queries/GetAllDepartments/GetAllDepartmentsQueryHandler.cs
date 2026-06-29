using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Responses;
using MediatR;
using HRManagement.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler:IRequestHandler<GetAllDepartmentsQuery,BaseResponse<List<DepartmentListVm>>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<BaseResponse<List<DepartmentListVm>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAllWithEmployeesAsync();

            var response = departments.Select(d=>d.ToDepartmentListVms()).ToList();

            return BaseResponse<List<DepartmentListVm>>.SuccessResponse(response, "Departments retrieved successfully");
        }
    }
}
