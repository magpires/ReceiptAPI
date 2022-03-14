using ReceiptAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Map
{
    public class ProductReceiptMap : IEntityTypeConfiguration<ProductReceipt>
    {
        public virtual void Configure(EntityTypeBuilder<ProductReceipt> modelBuilder)
        {
            modelBuilder.ToTable("product_receipt");
            modelBuilder.HasKey(pr => pr.Id);
            modelBuilder.Property(pr => pr.Id).HasColumnName("id").ValueGeneratedOnAdd();
            modelBuilder.Property(pr => pr.ProductId).HasColumnName("product_id").IsRequired();
            modelBuilder.Property(pr => pr.ReceiptId).HasColumnName("receipt_id").IsRequired();

            modelBuilder.HasOne(pr => pr.Product)
                .WithMany()
                .HasForeignKey(pr => pr.ProductId);

            modelBuilder.HasOne(pr => pr.Receipt)
                .WithMany()
                .HasForeignKey(pr => pr.ReceiptId);
        }
    }
}
