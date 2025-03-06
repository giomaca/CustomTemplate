using CustomTemplate.Domain.Errors;
using FluentValidation;

namespace CustomTemplate.Application.Features.Customers.Commands.CreateCustomer;

class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(element => element.FirstName)
            .NotNull()
            .NotEmpty()
            .WithMessage(DomainErrors.General.Required("FirstName"));

        RuleFor(element => element.LastName)
            .NotNull()
            .NotEmpty()
            .WithMessage(DomainErrors.General.Required("LastName"));


        RuleFor(element => element.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage(DomainErrors.General.Required("Email"));
    }
}
