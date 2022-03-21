using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReceiptAPI.Entities;
using ReceiptAPI.Enumerators;

namespace ReceiptAPI.Configurations
{
    public class ReceiptMap : BaseEntityMap<Receipt>
    {
        public ReceiptMap() : base("receipts") { }

        public override void Configure(EntityTypeBuilder<Receipt> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder.Property(x => x.PaymentMethod)
                .HasColumnName("payment_method")
                .HasDefaultValue(PaymentMethod.CASH);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Receipts)
                .HasForeignKey(x => x.CustomerId);

            builder.HasMany(x => x.Products)
                .WithMany(x => x.Receipts)
                .UsingEntity<ProductReceipt>(
                    x => x.HasOne(p => p.Product).WithMany(pr => pr.ProductReceipts).HasForeignKey(x => x.ProductId),
                    x => x.HasOne(p => p.Receipt).WithMany(pr => pr.ProductReceipts).HasForeignKey(x => x.ReceiptId),
                    x =>
                    {
                        x.ToTable("product_receipt");
                        x.HasKey(p => new { p.ProductId, p.ReceiptId });
                        x.Property(p => p.ProductId).HasColumnName("product_id").IsRequired();
                        x.Property(p => p.ReceiptId).HasColumnName("receipt_id").IsRequired();
                        x.Property(p => p.Quantity).HasDefaultValue(1);
                    }
                );
        }
    }
}
