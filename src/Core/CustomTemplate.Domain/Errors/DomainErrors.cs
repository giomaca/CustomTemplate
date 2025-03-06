using FluentResults;

namespace CustomTemplate.Domain.Errors;

public static class DomainErrors
{
    public static class General
    {
        public static readonly Func<string, string> Required = key => new($"The parameter {key} is required.");
        public static readonly Func<Exception, Error> Unknown = exception => new($"Unknown error. Message: {exception.Message}: StackTrace: {exception.StackTrace}");
    }

    public static class Customer
    {
        public static readonly Func<string, Error> AlreadyExists = key => new($"The user with {key} already exists.");
    }
}
