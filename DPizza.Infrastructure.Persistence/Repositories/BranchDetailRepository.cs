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
    public class BranchDetailRepository : GenericRepository<BranchDetail>, IBranchDetailRepository
    {
        private readonly DbSet<BranchDetail> branchDetail;
        private readonly IMapper _mapper;

        public BranchDetailRepository(DPizzaContext dbContext, IMapper mapper) : base(dbContext)
        {
            branchDetail = dbContext.Set<BranchDetail>();
            _mapper = mapper;
        }

        public async Task<BranchDetail> GetBranchDetailByIdAsync(long id)
        {
            var query = await branchDetail
                       .FirstOrDefaultAsync(a => a.Id == id);

            return query;
        }

        public async Task<PagenationResponseDto<BranchDetailDto>> GetPagedListAsync(int pageNumber, int pageSize, string city)
        {
            var query = branchDetail                
                .OrderBy(p => p.CreatedDate).AsQueryable();

            if (!string.IsNullOrEmpty(city))
            {
                query = branchDetail
                      .Where(a => a.City == city);
            }

            return await Paged(
                query.Select(p => new BranchDetailDto(p)),
                pageNumber,
                pageSize);

        }
    }
}
