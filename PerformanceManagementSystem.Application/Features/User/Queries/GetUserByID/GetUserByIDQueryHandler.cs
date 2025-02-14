using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.User.Queries.GetUserByID
{
    public class GetUserByIDQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetUserByIDQuery, Result<UserDtoResponse>>
    {
        public async Task<Result<UserDtoResponse>> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            var user = unitOfWork.UserRepository.GetByIdAsync(request.ID).Result;
            if (user == null)
                return Result<UserDtoResponse>.NotFound("User Not found");
            return Result<UserDtoResponse>.Ok(user.Adapt<UserDtoResponse>());
        }
    }
}
