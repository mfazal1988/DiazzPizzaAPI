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
using System.Threading.Tasks;

namespace DPizza.Infrastructure.Persistence.Repositories
{
    public class ProductDetailRepository : GenericRepository<ProductDetail>, IProductDetailRepository
    {
        private readonly DbSet<ProductDetail> productsDetail;
        private readonly IMapper _mapper;

        public ProductDetailRepository(DPizzaContext dbContext, IMapper mapper) : base(dbContext)
        {
            productsDetail = dbContext.Set<ProductDetail>();
            _mapper = mapper;

        }

        public async Task<ProductDetail> GetProductDetailByIdAsync(long id)
        {
            var query = await productsDetail
                       .Include(p => p.ProductPrice)
                       .FirstOrDefaultAsync(a => a.Id == id);

            return query;
        }

        public async Task<PagenationResponseDto<ProductDetailDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
        {
            var query = productsDetail
                .Include(p => p.ProductPrice)
                .OrderBy(p => p.CreatedDate).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = productsDetail                      
                      .Where(a => a.Id ==Convert.ToInt32(name));
            }

            return await Paged(
                query.Select(p => new ProductDetailDto(p)),
                pageNumber,
                pageSize);

        }

        public async Task<ProductDetail> GetProductDetailByVarietyAsync(long productId, int crustTypeId, int productVarientId)
        {
            var query = await productsDetail
                       .Include(p => p.ProductPrice)
                       .FirstOrDefaultAsync(a => a.ProductId == productId && a.CrustTypeId == crustTypeId && a.ProductVarientId == productVarientId
                       && a.ProductPrice.IsCurrent == true);

            return query;
        }
        
    }
}
