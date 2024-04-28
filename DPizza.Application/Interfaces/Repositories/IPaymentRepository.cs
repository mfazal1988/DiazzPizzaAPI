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
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<PagenationResponseDto<PaymentDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);
        Task<Payment> GetPaymentByIdAsync(long id);
        List<Payment> GetPaymentByUserIdAsync(string id);
        List<Payment> GetPaymentByOrderIdAsync(long id);

    }
}
