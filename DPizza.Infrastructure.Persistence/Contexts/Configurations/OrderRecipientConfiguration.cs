using DPizza.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPizza.Infrastructure.Persistence.Contexts.Configurations
{
    public class OrderRecipientConfiguration : IEntityTypeConfiguration<OrderRecipient>
    {
        public void Configure(EntityTypeBuilder<OrderRecipient> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.OrderId);
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Address).HasMaxLength(200);
            builder.Property(p => p.City).HasMaxLength(50);
            builder.Property(p => p.Email).HasMaxLength(100);
            builder.Property(p => p.ContactNumber).HasMaxLength(20);

            builder.Property(p => p.IsDeleted).HasDefaultValue(0);
        }
    }
}
