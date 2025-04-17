using CustomTemplate.Application.Abstractions.Messaging;

namespace CustomTemplate.Application.Features.Customers.Commands.CreateCustomer;

public sealed record CreateCustomerCommand(
    string FirstName,
    string? MiddleName,
    string LastName,
    string Email
) : ICommand<Guid>;