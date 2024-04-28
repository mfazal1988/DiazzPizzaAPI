using DPizza.Application.DTOs;
using DPizza.Domain.Models.Dtos;
using DPizza.Domain.Models.Entities;
using System.Threading.Tasks;

namespace DPizza.Application.Interfaces.Repositories
{
    public interface IProductDetailRepository : IGenericRepository<ProductDetail>
    {
        Task<PagenationResponseDto<ProductDetailDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);

        Task<ProductDetail> GetProductDetailByIdAsync(long id);
        Task<ProductDetail> GetProductDetailByVarietyAsync(long productId, int crustTypeId, int productVarientId);
    }
}
