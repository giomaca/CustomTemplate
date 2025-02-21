using CustomTemplate.Domain.Entities;
using CustomTemplate.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomTemplate.Persistence.Configurations;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(TableNames.Customer);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.MiddleName);
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.PersonalNumber);
        builder.Property(x => x.Gender);
        builder.Property(x => x.BirthDate);
        builder.Property(x => x.Contact);
        builder.Property(x => x.Address);

        builder.OwnsOne(x => x.Contact, y =>
        {
            y.Property(a => a.Phone);
            y.Property(a => a.Email).IsRequired();
        }).Navigation(x => x.Contact);

        builder.OwnsOne(x => x.Address, y =>
        {
            y.Property(a => a.Street).IsRequired();
            y.Property(a => a.City).IsRequired();
            y.Property(a => a.State);
            y.Property(a => a.ZipCode).IsRequired();
            y.Property(a => a.Country).IsRequired();
        }).Navigation(x => x.Contact);
    }
}
