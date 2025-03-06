namespace CustomTemplate.API.Contracts.Customer;

public sealed record CreateCustomerRequest(
    string FirstName,
    string? MiddleName,
    string LastName,
    string Email);