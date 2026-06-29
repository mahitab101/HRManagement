using HRManagement.Application.Features.Positions.Commands.CreatePosition;
using HRManagement.Application.Features.Positions.Queries.GetAllPositions;
using HRManagement.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HRManagement.Application.Mappings.Positions
{
    public static class PositionMappingExtensions
    {
        public static Position ToEntity(this CreatePositionCommand command)
        {
            return new Position
            {
                Title = command.Title,
                DepartmentId = command.DepartmentId,
                BaseSalary = command.BaseSalary
            };
        }

        public static PositionListVm ToPositionListVm(this Position position)
        {
            return new PositionListVm
            {
                Id = position.Id,
                Title = position.Title,
                BaseSalary = position.BaseSalary,
                DepartmentId = position.DepartmentId,
                DepartmentName = position.Department?.Name
            };
        }

        public static List<PositionListVm> ToPositionListVms(this IEnumerable<Position> positions)
        {
            return positions.Select(p => p.ToPositionListVm()).ToList();
        }
    }
}