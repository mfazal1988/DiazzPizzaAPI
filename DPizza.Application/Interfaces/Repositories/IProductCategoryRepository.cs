using DPizza.Application.DTOs;
using DPizza.Domain.Models.Dtos;
using DPizza.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Interfaces.Repositories
{
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
    {
        Task<PagenationResponseDto<ProductCategoryDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);
        Task<ProductCategory> GetProductByIdAsync(long id);
    }
}
