using AutoMapper;
using DPizza.Application.DTOs;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Domain.Models.Dtos;
using DPizza.Domain.Models.Entities;
using DPizza.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Infrastructure.Persistence.Repositories
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        private readonly DbSet<ProductCategory> productCategory;
        private readonly IMapper _mapper;

        public ProductCategoryRepository(DPizzaContext dbContext, IMapper mapper) : base(dbContext)
        {
            productCategory = dbContext.Set<ProductCategory>();
            _mapper = mapper;
        }

        public async Task<ProductCategory> GetProductByIdAsync(long id)
        {
            var query = await productCategory                      
                       .FirstOrDefaultAsync(a => a.Id == id);

            return query;
        }

        public async Task<PagenationResponseDto<ProductCategoryDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
        {
            var query = productCategory.OrderBy(p => p.CreatedDate).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            return await Paged(
                query.Select(p => new ProductCategoryDto(p)),
                pageNumber,
                pageSize);

        }
    }
}
