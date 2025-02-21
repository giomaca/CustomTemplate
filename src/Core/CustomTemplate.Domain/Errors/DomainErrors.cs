using FluentResults;

namespace CustomTemplate.Domain.Errors;

public static class DomainErrors
{
    public static class General
    {
        public static readonly Error Unknown = new("Error");
    }

    public static class Customer
    {
        public static readonly Func<string, Error> AlreadyExists = key => new($"The user with {key} already exists.");
    }
}
