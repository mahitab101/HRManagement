using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandValidator:AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(d=>d.Name).NotEmpty().WithMessage("{PropertyName} is required"); ;
        }
    }
}
