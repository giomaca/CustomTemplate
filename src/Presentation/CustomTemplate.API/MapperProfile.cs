using CustomTemplate.API.Contracts.Customer;
using CustomTemplate.Application.Features.Customers.Commands.CreateCustomer;
using CustomTemplate.Domain.ValueObjects;
using Mapster;

namespace CustomTemplate.API;

public class MapperProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
    }
}
