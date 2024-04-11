﻿using DPizza.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPizza.Infrastructure.Persistence.Contexts.Configurations
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVarient>
    {
        public void Configure(EntityTypeBuilder<ProductVarient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Description).HasMaxLength(50);
            builder.Property(p => p.IsDeleted).HasDefaultValue(0);
        }
    }
}
