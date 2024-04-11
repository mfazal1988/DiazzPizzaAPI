using DPizza.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DPizza.Infrastructure.Persistence.Contexts.Configurations
{
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.ProductId).IsRequired();
            builder.Property(p => p.CrustTypeId);
            builder.Property(p => p.ProductVarientId);
            //builder.Property(p => p.ProductPriceId);
            builder.Property(p => p.IsDeleted).HasDefaultValue(0);

            //builder.HasOne(x => x.Product)
            //       .WithMany()
            //       .HasForeignKey(x => x.ProductId);

            //builder.HasOne(x => x.ProductPrice)
            //          .WithOne()
            //          .HasForeignKey<ProductDetail>(x => x.ProductPriceId);

            builder.HasOne<Product>()
                            .WithMany(p => p.ProductDetails)
                            .HasForeignKey(x => x.ProductId);
        }
    }
}
