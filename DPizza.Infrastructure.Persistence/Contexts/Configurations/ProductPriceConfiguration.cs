using DPizza.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPizza.Infrastructure.Persistence.Contexts.Configurations
{
    public class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPrice>
    {
        public void Configure(EntityTypeBuilder<ProductPrice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.ProductDetailId);
            builder.Property(p => p.ValidFrom).HasMaxLength(50);
            builder.Property(p => p.ValidTo).HasMaxLength(50);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.IsCurrent);
            builder.Property(p => p.IsDeleted).HasDefaultValue(0);

            builder.HasOne<ProductDetail>()
                            .WithOne(p => p.ProductPrice)
                            .HasForeignKey<ProductPrice>(x => x.ProductDetailId);
       
    }
}
}
