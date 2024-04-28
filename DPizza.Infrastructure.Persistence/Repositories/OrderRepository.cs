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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DPizza.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DbSet<Order> order;
        private readonly IMapper _mapper;

        public OrderRepository(DPizzaContext dbContext, IMapper mapper) : base(dbContext)
        {
            order = dbContext.Set<Order>();
            _mapper = mapper;
        }

        public async Task<Order> GetOrderByIdAsync(long id)
        {
            var query = await order
                        .Include(p => p.OrderDetails)
                        //.ThenInclude(p => p.ProductDetailID)
                       .Include(p => p.OrderRecipient)
                       .FirstOrDefaultAsync(a => a.Id == id);

            return query;
        }

        //public List<Order> GetOrderByUserIdAsync(long id)
        //{
        //    var query = order
        //                .Include(p => p.OrderDetails)
        //               .Include(p => p.OrderRecipient)
        //               .Where(a => a.UserId == id).ToList();

        //    return query;
        //}

        //public List<Order> GetOrderByCreatedUserAsync(string id)
        //{
        //    var query = order
        //                .Include(p => p.OrderDetails)
        //               .Include(p => p.OrderRecipient)
        //               .Where(a => a.CreatedBy == Guid.Parse(id)).ToList();

        //    return query;
        //}

        public async Task<PagenationResponseDto<OrderDto>> GetOrderByUserIdAsync(int pageNumber, int pageSize, long id)
        {
            var query = order
                         .Include(p => p.OrderDetails)
                         .Include(p => p.OrderRecipient)
                         .OrderBy(p => p.CreatedDate).AsQueryable();

            if (id > 0)
            {
                query = query.Where(a => a.UserId == id);
            }

            return await Paged(
                 query.Select(p => new OrderDto(p)),
                 pageNumber,
                 pageSize);
        }


        public async Task<PagenationResponseDto<OrderDto>> GetOrderByCreatedUserAsync(int pageNumber, int pageSize, string guid)
        {
            var query = order
                         .Include(p => p.OrderDetails)
                        .Include(p => p.OrderRecipient)
                         .OrderBy(p => p.CreatedDate).AsQueryable();

            if (!string.IsNullOrEmpty(guid))
            {
                query = query.Where(a => a.CreatedBy == Guid.Parse(guid));
            }

            return await Paged(
                 query.Select(p => new OrderDto(p)),
                 pageNumber,
                 pageSize);
        }

        public async Task<PagenationResponseDto<OrderDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
        {
            var query = order
                .Include(p => p.OrderDetails)
                .Include(p => p.OrderRecipient)
                .OrderBy(p => p.CreatedDate).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.OrderNumber.Contains(name));
            }

            return await Paged(
                query.Select(p => new OrderDto(p)),
                pageNumber,
                pageSize);

        }
    }
}
