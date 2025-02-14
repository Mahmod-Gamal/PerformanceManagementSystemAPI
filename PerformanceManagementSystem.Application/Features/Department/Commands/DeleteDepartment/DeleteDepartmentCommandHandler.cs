using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteDepartmentCommand, Result<AcknowledgmentDtoResponse>>
    {
        public async Task<Result<AcknowledgmentDtoResponse>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = unitOfWork.DepartmentRepository.GetByIdAsync(request.ID).Result;
            if (department is null)
                return Result<AcknowledgmentDtoResponse>.NotFound("Department Not Found");
            unitOfWork.DepartmentRepository.Remove(department);
            //await unitOfWork.CommitAsync(cancellationToken);
            return Result<AcknowledgmentDtoResponse>.Ok(new("Deleted Successfully"));
        }
    }
}
