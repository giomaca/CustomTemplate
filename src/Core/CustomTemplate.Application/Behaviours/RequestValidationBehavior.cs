using FluentResults;
using FluentValidation;
using MediatR;

namespace CustomTemplate.Application.Behaviours;

public class RequestValidationBehavior<TRequest, TResponse>(IValidator<TRequest>[] validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        Error[] failures = validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .Select(f => new Error(f.ErrorMessage))
            .ToArray();

        if (failures.Length != 0)
        {
            return (Result.Fail(failures) as TResponse)!;
        }

        return await next();
    }
}
