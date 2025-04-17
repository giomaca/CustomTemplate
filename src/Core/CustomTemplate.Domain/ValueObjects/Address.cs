using CustomTemplate.Domain.Primitives;

namespace CustomTemplate.Domain.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string? State { get; private set; }
    public string ZipCode { get; private set; }
    public string Country { get; private set; }

    private Address(
        string street,
        string city,
        string state,
        string zipCode,
        string country)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Country = country;
    }

    public static Address Create(
        string street,
        string city,
        string state,
        string zipCode,
        string country)
            => new(street, city, state, zipCode, country);

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Street;
        yield return City;
        if (!string.IsNullOrWhiteSpace(State))
            yield return State;
        yield return ZipCode;
        yield return Country;
    }
}
