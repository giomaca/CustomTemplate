using CustomTemplate.Domain.Primitives;

namespace CustomTemplate.Domain.ValueObjects;

public class Contact : ValueObject
{
    public string? Phone { get; private set; }
    public string Email { get; private set; }

    private Contact(string email, string? phone)
    {
        Phone = phone;
        Email = email;
    }

    public static Contact Create(string email, string? phone = null) => new(email, phone);

    public override IEnumerable<object> GetAtomicValues()
    {
        if(!string.IsNullOrWhiteSpace(Phone))
            yield return Phone;
        yield return Email;
    }
}
