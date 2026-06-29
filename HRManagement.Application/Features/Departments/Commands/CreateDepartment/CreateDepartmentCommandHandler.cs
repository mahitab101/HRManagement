using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings;
using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, BaseResponse<CreateDepartmentCommandResponse>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<BaseResponse<CreateDepartmentCommandResponse>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var newDepartment = request.ToEntity();
            var created = await _departmentRepository.AddAsync(newDepartment);

            var response = new CreateDepartmentCommandResponse { Id = created.Id };

            return BaseResponse<CreateDepartmentCommandResponse>.SuccessResponse(response, "Department created successfully");
        }
    }
}
