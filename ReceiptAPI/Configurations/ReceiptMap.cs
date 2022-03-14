using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReceiptAPI.Entities;

namespace ReceiptAPI.Configurations
{
    public class ReceiptMap : BaseEntityMap<Receipt>
    {
        public ReceiptMap() : base("receipt") { }

        public override void Configure(EntityTypeBuilder<Receipt> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder.Property(x => x.PaymentMethod)
                .HasColumnName("payment_method");
        }
    }
}
