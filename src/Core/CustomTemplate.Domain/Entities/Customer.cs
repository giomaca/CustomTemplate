using CustomTemplate.Domain.Enums;
using CustomTemplate.Domain.Primitives;
using CustomTemplate.Domain.ValueObjects;

namespace CustomTemplate.Domain.Entities;

public class Customer : AggregateRoot
{
    public string FirstName { get; private set; }
    public string? MiddleName { get; private set; }
    public string LastName { get; private set; }
    public string? PersonalNumber { get; private set; }
    public Gender? Gender { get; private set; }
    public DateOnly? BirthDate { get; private set; }
    public Contact Contact { get; private set; }
    public Address? Address { get; private set; }


    private Customer(
        Guid id,
        string firstName,
        string? middleName,
        string lastName,
        string? personalNumber,
        Gender gender,
        DateOnly? birthDate,
        Contact contact,
        Address? address) : base(id)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        PersonalNumber = personalNumber;
        Gender = gender; 
        BirthDate = birthDate;
        Contact = contact;
        Address = address;
    }

    private Customer(
        Guid id,
        string firstName,
        string? middleName,
        string lastName,
        Contact contact) : base(id)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        Contact = contact;
    }

    public static Customer Create(
        Guid id,
        string firstName,
        string? middleName,
        string lastName,
        Contact contact)
        => new(
            id,
            firstName,
            middleName,
            lastName,
            contact);

    public static Customer Verify(
        Guid id,
        string firstName,
        string? middleName,
        string lastName,
        string personalNumber,
        Gender gender,
        DateOnly? birthDate,
        Contact contact,
        Address? address)
        => new(
            id,
            firstName,
            middleName,
            lastName,
            personalNumber,
            gender,
            birthDate,
            contact,
            address);
}
