using CustomTemplate.Application.Abstractions.Messaging;
using CustomTemplate.Domain.Entities;
using CustomTemplate.Domain.Errors;
using CustomTemplate.Domain.Repositories;
using CustomTemplate.Domain.ValueObjects;
using FluentResults;

namespace CustomTemplate.Application.Features.Customers.Commands;

internal sealed class CreateCustomerCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<CreateCustomerCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await unitOfWork.BeginTransactionAsync();
            var repository = unitOfWork.GetRepository<Customer>();
            var existsCustomer = repository.GetAsync().Where(x => x.Contact.Email == request.Email).FirstOrDefault();
            if (existsCustomer is not null)
                return Result.Fail(DomainErrors.Customer.AlreadyExists(request.Email));

            var customer = Customer.Create(
                Guid.NewGuid(),
                request.FirstName,
                request.MiddleName,
                request.LastName,
                Contact.Create(request.Email));

            var res = await repository.AddAsync(customer);
            await unitOfWork.CommitAsync();
            return res.Id;

        }
        catch(Exception ex)
        {
            await unitOfWork.RollbackAsync();
        }
    }
}
