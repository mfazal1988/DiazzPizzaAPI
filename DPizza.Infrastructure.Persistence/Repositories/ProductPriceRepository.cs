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
    public class ProductPriceRepository : GenericRepository<ProductPrice>, IProductPriceRepository
    {
        private readonly DbSet<ProductPrice> productPrice;
        private readonly IMapper _mapper;

        public ProductPriceRepository(DPizzaContext dbContext, IMapper mapper) : base(dbContext)
        {
            productPrice = dbContext.Set<ProductPrice>();
            _mapper = mapper;

        }

        public async Task<ProductPrice> GetProductByIdAsync(long id)
        {
            var query = await productPrice
                       .FirstOrDefaultAsync(a => a.Id == id);

            return query;
        }

        public async Task<PagenationResponseDto<ProductPriceDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
        {
            var query = productPrice
                .OrderBy(p => p.CreatedDate).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = productPrice                      
                      .Where(a => a.Id ==Convert.ToInt32(name));
            }

            return await Paged(
                query.Select(p => new ProductPriceDto(p)),
                pageNumber,
                pageSize);

        }
    }
}
