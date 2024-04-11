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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DbSet<Order> order;
        private readonly IMapper _mapper;

        public OrderRepository(DPizzaContext dbContext, IMapper mapper) : base(dbContext)
        {
            order = dbContext.Set<Order>();
            _mapper = mapper;
        }

        public async Task<Order> GetProductByIdAsync(long id)
        {
            var query = await order
                       .FirstOrDefaultAsync(a => a.Id == id);

            return query;
        }

        public async Task<PagenationResponseDto<OrderDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
        {
            var query = order.OrderBy(p => p.CreatedDate).AsQueryable();

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
