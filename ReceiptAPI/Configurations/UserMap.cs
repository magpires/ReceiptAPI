using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReceiptAPI.Entities;

namespace ReceiptAPI.Configurations
{
    public class UserMap : BaseMap<User>
    {
        public UserMap() : base("users") { }

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(255)").IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Password).HasColumnName("password").HasColumnType("varchar(255)").IsRequired();
        }
    }
}
