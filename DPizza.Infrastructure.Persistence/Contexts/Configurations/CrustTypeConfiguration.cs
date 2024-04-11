using DPizza.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPizza.Infrastructure.Persistence.Contexts.Configurations
{
    public class CrustTypeConfiguration : IEntityTypeConfiguration<CrustType>
    {
        public void Configure(EntityTypeBuilder<CrustType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(200);
            builder.Property(p => p.IsDeleted).HasDefaultValue(0);
        }
    }
}
