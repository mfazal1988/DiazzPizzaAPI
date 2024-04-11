using DPizza.Application.Interfaces;
using System.Threading.Tasks;

namespace DPizza.Infrastructure.Persistence.Contexts
{
    public class UnitOfWork(DPizzaContext dbContext) : IUnitOfWork
    {
        public async Task<bool> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync() > 0;
        }
        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }
    }
}
