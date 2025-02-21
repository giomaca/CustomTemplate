using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomTemplate.Application.Behaviours;

public class LoggingBehaviour<TRequest, TResponse>(ILogger<LoggingBehaviour<TRequest, TResponse>> logger) 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Incoming request {@RequestName} {@Payload} at {@DateTime}",
            typeof(TRequest).Name,
            request,
            DateTime.Now
        );

        var result = await next();

        result.LogIfFailed(
            context: string.Format($"Failed request {{@RequestName}}, {{@Error}}, {{@DateTime}}",
                typeof(TRequest).Name,
                result.Errors.Select(error => error.Message),
                DateTime.Now), 
           logLevel: LogLevel.Error);

        result.LogIfSuccess(
            context: string.Format($"Completed request {{@RequestName}}, {{@DateTime}}",
                typeof(TRequest).Name,
                DateTime.Now),
            logLevel: LogLevel.Error);

        //if (result.IsFailed)
        //{
        //    logger.LogError(
        //        "Request failed {@RequestName}, {@Error}, {@DateTime}",
        //        typeof(TRequest).Name,
        //        result.Errors.Select(error => error.Message),
        //        DateTime.Now
        //    );
        //}

        //_logger.LogInformation(
        //    "Completed request {@RequestName}, {@DateTime}",
        //    typeof(TRequest).Name,
        //    DateTime.Now
        //);

        return result;
    }
}
