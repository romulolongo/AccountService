using AccountServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountServices.Infra.Data.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {

        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Guid)
                .HasName("Guid");

            builder.Property(x => x.HolderAccountName)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(x => x.ValueBalance)
               .IsRequired();

            builder.Property(x => x.ValueLimit)
               .IsRequired();

            builder.Property(x => x.Blocked)
               .IsRequired();
        }
    }
}
