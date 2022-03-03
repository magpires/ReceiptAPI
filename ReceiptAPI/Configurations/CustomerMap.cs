using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReceiptAPI.Entities;

namespace ReceiptAPI.Configurations
{
    public class CustomerMap : BaseMap<Customer>
    {
        public CustomerMap() : base("customers") { }

        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(100)");

            builder.Property(x => x.PhoneNumber)
                .HasColumnName("phone_number")
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(x => x.HouseNumber)
                .HasColumnName("house_number")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(x => x.PostalCode)
                .HasColumnName("postal_code")
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(x => x.Street)
                .HasColumnName("street")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(x => x.District)
                .HasColumnName("district")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(x => x.City)
                .HasColumnName("city")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(x => x.State)
                .HasColumnName("state")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.HasIndex(c => new { c.Email, c.PhoneNumber })
                .IsUnique();
        }
    }
}
