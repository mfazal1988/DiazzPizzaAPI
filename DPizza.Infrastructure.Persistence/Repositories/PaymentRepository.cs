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
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly DbSet<Payment> payment;
        private readonly IMapper _mapper;

        public PaymentRepository(DPizzaContext dbContext, IMapper mapper) : base(dbContext)
        {
            payment = dbContext.Set<Payment>();
            _mapper = mapper;
        }

        public async Task<Payment> GetProductByIdAsync(long id)
        {
            var query = await payment
                       .FirstOrDefaultAsync(a => a.Id == id);

            return query;
        }

        public async Task<PagenationResponseDto<PaymentDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
        {
            var query = payment.OrderBy(p => p.CreatedDate).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.TransactionId.Contains(name));
            }

            return await Paged(
                query.Select(p => new PaymentDto(p)),
                pageNumber,
                pageSize);

        }
    }
}
