using DPizza.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPizza.Infrastructure.Persistence.Contexts.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => x.Id);        

            builder.Property(p => p.Name).HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.IsDeleted).HasDefaultValue(0);
        }
    }
}
