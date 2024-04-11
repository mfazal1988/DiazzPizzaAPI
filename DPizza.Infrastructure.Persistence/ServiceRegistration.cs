using DPizza.Application.Interfaces;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Infrastructure.Persistence.Contexts;
using DPizza.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace DPizza.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DPizzaContext>(options =>
           options.UseSqlServer(
               configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(DPizzaContext).Assembly.FullName)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.RegisterRepositories();

        }
        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            var interfaceType = typeof(IGenericRepository<>);
            var interfaces = Assembly.GetAssembly(interfaceType).GetTypes()
                .Where(p => p.GetInterface(interfaceType.Name.ToString()) != null);

            foreach (var item in interfaces)
            {
                var implimentation = Assembly.GetAssembly(typeof(GenericRepository<>)).GetTypes()
                    .FirstOrDefault(p => p.GetInterface(item.Name.ToString()) != null);
                services.AddTransient(item, implimentation);

            }

        }
    }
}
