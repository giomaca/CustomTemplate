using FluentResults;
using MediatR;

namespace CustomTemplate.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;