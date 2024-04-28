using DPizza.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPizza.Infrastructure.Persistence.Contexts.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.OrderID);
            builder.Property(p => p.ProductDetailID);
            builder.Property(p => p.Quantity);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.CouponDiscount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.CreditCardDiscount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.OtherDiscount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.NetTotal).HasColumnType("decimal(18,2)");

            builder.Property(p => p.IsDeleted).HasDefaultValue(0);

            //builder.HasOne(d => d.Order)
            //  .WithMany(p => p.OrderDetails)
            //  .HasForeignKey(d => d.OrderID)
            //  .OnDelete(DeleteBehavior.ClientSetNull)
            //  .HasConstraintName("FK_OrderDetails_Order");

            //builder.HasOne(x => x.ProductDetail)
            //       .WithOne() 
            //       .HasForeignKey<OrderDetail>(x => x.ProductDetailID);

            builder.HasOne<Order>()
                            .WithMany(p => p.OrderDetails)
                            .HasForeignKey(x => x.OrderID);

        }
    }
}
