
using DPizza.Domain.Models.Dtos;
using DPizza.Domain.Models.Entities;
using DPizza.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Infrastructure.Persistence.Seeds
{
    public static class BranchDetailData
    {
        public static async Task SeedAsync(DPizzaContext dbContext)
        {
            try
            {
                var branchDetail = new List<BranchDetailDto>
            {
                new BranchDetailDto {  Number = "202/A", Address1 = "Queens Road", Address2 = "Colombo 03", City = "Colombo", ContactNumber = "00112548"}
            };

                //builder.HasData(branchDetails);

                dbContext.Set<BranchDetailDto>().AddRange(branchDetail);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while seeding data: {ex}");
            }
        }
    }
}
