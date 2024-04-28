using DPizza.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPizza.Infrastructure.Persistence.Contexts.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.UserId);
            builder.Property(p => p.OrderNumber)
               .HasMaxLength(100);
            builder.Property(p => p.OrderTypeId);
            //builder.Property(p => p.OrderRecipientId);
            builder.Property(p => p.OrderStatusId);
            builder.Property(p => p.AdditionalInstruction)
                .HasMaxLength(500);
            builder.Property(p => p.AdditionalNotes)
                .HasMaxLength(500);
            builder.Property(p => p.DeliveryPerson)
                .HasMaxLength(100);
            builder.Property(p => p.LocationLink)
                .HasMaxLength(500);
            builder.Property(p => p.IsOrderForSelf);
            builder.Property(p => p.BranchId);

            builder.Property(p => p.IsDeleted).HasDefaultValue(0);

            //builder
            //    .HasOne(d => d.OrderRecipient)
            //    .WithOne()
            //    .HasForeignKey<Order>(da => da.OrderRecipientId);

        }
    }
}
