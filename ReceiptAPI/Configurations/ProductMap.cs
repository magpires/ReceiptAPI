using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReceiptAPI.Entities;

namespace ReceiptAPI.Configurations
{
    public class ProductMap : BaseEntityMap<Product>
    {
        public ProductMap() : base("products") { }

        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnName("price")
                .HasDefaultValue(0.0)
                .IsRequired();

            builder.HasMany(p => p.ProductReceipts)
                .WithOne(p => p.Product)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
