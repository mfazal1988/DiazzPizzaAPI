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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DbSet<Product> products;
        //private readonly IQueryable<Product> products;
        private readonly IMapper _mapper;

        public ProductRepository(DPizzaContext dbContext, IMapper mapper) : base(dbContext)
        {
            products = dbContext.Set<Product>();
            _mapper = mapper;

            //products = (DbSet<Product>)
            //products = dbContext.Set<Product>().Include(p => p.ProductDetails);
            //products = (DbSet<Product>)dbContext.Set<Product>().Include(p => p.ProductDetails);
            //var users = dbContext.Products.ToList();
        }

        //public async Task<ProductDto> GetByIdAsync3(long id)
        //{
        //    var query = await products
        //                   .Include(p => p.ProductDetails)
        //                   .FirstOrDefaultAsync(a => a.Id == id);

        //    return _mapper.Map<ProductDto>(query);
        //}

        public async Task<Product> GetProductByIdAsync(long id)
        {
            var query = await products
                       .Include(p => p.ProductDetails)
                       .ThenInclude(p => p.ProductPrice)
                       .FirstOrDefaultAsync(a => a.Id == id);

            return query;
        }

        public async Task<PagenationResponseDto<ProductDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
        {
            var query = products
                .Include(p => p.ProductDetails)
                .ThenInclude(p => p.ProductPrice)
                .OrderBy(p => p.CreatedDate).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                //query = query.Where(p => p.Name.Contains(name));
                query = products                      
                      .Where(a => a.Name == name);
            }

            return await Paged(
                query.Select(p => new ProductDto(p)),
                pageNumber,
                pageSize);

        }

        //public async Task<PagenationResponseDto<Product>> GetPagedListAsync2(int pageNumber, int pageSize, string name)
        //{
        //    var query = products.OrderBy(p => p.CreatedDate).AsQueryable();

        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        query = query.Where(p => p.Name.Contains(name));
        //    }

        //    return await Paged(
        //        query.Select(p => new ProductDto(p)),
        //        pageNumber,
        //        pageSize);

        //}


    }
}
