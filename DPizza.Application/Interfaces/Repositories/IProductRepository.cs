using DPizza.Application.DTOs;
using DPizza.Domain.Models.Dtos;
using DPizza.Domain.Models.Entities;
using System.Threading.Tasks;

namespace DPizza.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<PagenationResponseDto<ProductDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);

        //Task<ProductDto> GetByIdAsync3(long id);
        Task<Product> GetProductByIdAsync(long id);
    }
}
