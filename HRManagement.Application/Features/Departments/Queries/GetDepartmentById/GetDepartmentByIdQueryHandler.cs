using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings;
using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryHandler:IRequestHandler<GetDepartmentByIdQuery,BaseResponse<DepartmentDetailsVm>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetDepartmentByIdQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<BaseResponse<DepartmentDetailsVm>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdWithDetailsAsync(request.Id);

            if (department == null)
                return BaseResponse<DepartmentDetailsVm>.FailureResponse($"Department with Id {request.Id} not found");
            var response = department.ToDepartmentDetailsVm();
            return BaseResponse<DepartmentDetailsVm>.SuccessResponse(response, "Data retrieved successfully");
        }
    }
}
