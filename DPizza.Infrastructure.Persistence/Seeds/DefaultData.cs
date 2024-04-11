using DPizza.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace DPizza.Infrastructure.Persistence.Seeds
{
    public static class DefaultData
    {
        public static async Task SeedAsync(DPizzaContext DPizzaContext)
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "SqlSeedData");

            if (Directory.Exists(dir))
            {
                foreach (var item in Directory.GetFiles(dir))
                {
                    var command = File.ReadAllText(item);
                    try
                    {
                        await DPizzaContext.Database.ExecuteSqlRawAsync(command);
                    }
                    catch
                    {
                    }
                }

                await DPizzaContext.SaveChangesAsync();
            }
        }
    }
}
