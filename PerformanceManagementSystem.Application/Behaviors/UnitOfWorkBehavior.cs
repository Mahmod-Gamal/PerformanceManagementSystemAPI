using MediatR;
using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Behaviors
{
    public class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                var response = await next();
                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to commit changes to the database.", ex);
            }
        }


    }
}