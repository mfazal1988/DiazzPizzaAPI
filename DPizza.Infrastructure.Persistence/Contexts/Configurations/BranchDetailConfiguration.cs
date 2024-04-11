using DPizza.Domain.Models.Dtos;
using DPizza.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace DPizza.Infrastructure.Persistence.Contexts.Configurations
{
    public class BranchDetailConfiguration : IEntityTypeConfiguration<BranchDetail>
    {
        public void Configure(EntityTypeBuilder<BranchDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Number).HasMaxLength(20);
            builder.Property(p => p.Address1).HasMaxLength(100);
            builder.Property(p => p.Address2).HasMaxLength(100);
            builder.Property(p => p.City).HasMaxLength(50);
            builder.Property(p => p.ContactNumber).HasMaxLength(50);

            builder.Property(p => p.IsDeleted).HasDefaultValue(0);

            // insert default data

            //var userId = Guid.Parse("00000000-0000-0000-0000-000000000001"); // Get the user ID from the authenticatedUser

            //var branchDetails = new List<BranchDetailDto>
            //{
            //    new BranchDetailDto {  Id = 1, Number = "202/A", Address1 = "Queens Road", Address2 = "Colombo 03", City = "Colombo",
            //        ContactNumber = "00112548" 
            //       //CreatedBy = userId.ToString(), LastModifiedBy = userId.ToString(), CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now,
            //        }
            //};

            //builder.HasData(branchDetails);
        }
    }
}
