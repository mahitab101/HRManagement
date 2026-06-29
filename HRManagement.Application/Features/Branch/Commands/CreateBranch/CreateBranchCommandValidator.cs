using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Branch.Commands.CreateBranch
{
    public class CreateBranchCommandValidator:AbstractValidator<CreateBranchCommand>
    {
        public CreateBranchCommandValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(150);

            RuleFor(b => b.Location)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(255);

        }
    }
}
