using DPizza.Application.DTOs;
using DPizza.Domain.Models.Dtos;
using DPizza.Domain.Models.Entities;
using System.Threading.Tasks;

namespace DPizza.Application.Interfaces.Repositories
{
    public interface IProductPriceRepository : IGenericRepository<ProductPrice>
    {
        Task<PagenationResponseDto<ProductPriceDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);

        Task<ProductPrice> GetProductByIdAsync(long id);
    }
}
