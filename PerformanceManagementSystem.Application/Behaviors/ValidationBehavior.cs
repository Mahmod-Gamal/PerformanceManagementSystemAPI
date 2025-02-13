using FluentValidation;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using System.Reflection;

namespace PerformanceManagementSystem.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : Result
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Any())
                {
                    var errorMessage = failures.First().ErrorMessage;

                    // ✅ Correctly create a Result<T> of the expected generic type
                    var resultType = typeof(TResponse).GetGenericArguments().FirstOrDefault();
                    if (resultType == null)
                        throw new InvalidOperationException("TResponse is not a generic Result<T>");

                    var badRequestMethod = typeof(Result<>)
                        .MakeGenericType(resultType)
                        .GetMethod(nameof(Result<object>.BadRequest));

                    var badRequestResult = badRequestMethod.Invoke(null, new object[] { errorMessage });

                    return (TResponse)badRequestResult;
                }
            }
            return await next();
        }
    }
}
