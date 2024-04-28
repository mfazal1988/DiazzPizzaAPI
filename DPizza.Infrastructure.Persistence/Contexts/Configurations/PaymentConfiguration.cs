using DPizza.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPizza.Infrastructure.Persistence.Contexts.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.OrderId);
            builder.Property(p => p.UserId);
            builder.Property(p => p.PaymentTypeId);
            builder.Property(p => p.Amount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PaymentStatusId);
            builder.Property(p => p.PaymentGatewayRequest);
            builder.Property(p => p.PaymentGatewayResponse);
            builder.Property(p => p.AdditionalInfo).HasMaxLength(500);
            builder.Property(p => p.TransactionId).HasMaxLength(200);

            builder.Property(p => p.IsDeleted).HasDefaultValue(0);

           // builder.HasOne(x => x.Order)
           //.WithOne()
           //.HasForeignKey<Payment>(x => x.OrderId);
        }
    }
}
