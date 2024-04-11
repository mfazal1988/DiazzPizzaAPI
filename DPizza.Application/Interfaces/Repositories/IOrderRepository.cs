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
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<PagenationResponseDto<OrderDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);
        Task<Order> GetProductByIdAsync(long id);
    }
}
