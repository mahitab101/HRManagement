using FluentValidation;
using HRManagement.Application.Common.Constants;

namespace HRManagement.Application.Features.Account.Commands.AssignRole
{
    public class AssignRoleCommandValidator : AbstractValidator<AssignRoleCommand>
    {
        private static readonly string[] ValidRoles = { Roles.Admin, Roles.HR, Roles.Employee };

        public AssignRoleCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required.")
                .Must(role => ValidRoles.Contains(role))
                .WithMessage($"Role must be one of: {string.Join(", ", ValidRoles)}.");
        }
    }
}