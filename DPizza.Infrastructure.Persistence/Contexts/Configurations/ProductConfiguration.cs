using DPizza.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPizza.Infrastructure.Persistence.Contexts.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasOne(d => d.ProductCategory)
            //    .WithMany(p => p.Products)
            //    .HasForeignKey(d => d.ProductCategoryId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Products_ProductCategory");

            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(200);
            builder.Property(p => p.IsDeleted).HasDefaultValue(0);

            //builder.HasOne(x => x.ProductDetail)
            //                .WithMany()
            //                .HasForeignKey(x => x.ProductDetail.ProductId);

            //builder.HasOne(x => x.ProductDetail)
            //         .WithOne()
            //         .HasForeignKey<ProductDetail>(x => x.ProductId);

            //builder.Navigation(x => x.ProductDetails)
            //  .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
