using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReceiptAPI.Entities;

namespace ReceiptAPI.Configurations
{
    public class CustomerMap : BaseEntityMap<Customer>
    {
        public CustomerMap() : base("customers") { }

        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(100);

            builder.Property(x => x.PhoneNumber)
                .HasColumnName("phone_number")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.HouseNumber)
                .HasColumnName("house_number")
                .IsRequired();

            builder.Property(x => x.PostalCode)
                .HasColumnName("postal_code")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.Street)
                .HasColumnName("street")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.District)
                .HasColumnName("district")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.City)
                .HasColumnName("city")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.State)
                .HasColumnName("state")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(c => new { c.Email, c.PhoneNumber })
                .IsUnique();
        }
    }
}
