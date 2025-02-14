using MediatR;
using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using System.Windows.Input;

namespace PerformanceManagementSystem.Application.Features.Department.Commands.AddDepartment
{
    public class AddDepartmentCommand : ICommand<Result<DepartmentDtoResponse>>
    {
        public string Name { get; set; }
        public int? ManagerId { get; set; }
    }
}
