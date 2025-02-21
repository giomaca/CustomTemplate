using FluentResults;

namespace CustomTemplate.Domain.Errors;

public static class DomainErrors
{
    public static class UserError
    {
        public static readonly Error UserNotFound = new(
            "User not found");
    }
}
