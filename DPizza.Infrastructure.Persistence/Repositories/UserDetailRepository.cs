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
    public class UserDetailRepository : GenericRepository<UserDetail>, IUserDetailRepository
    {
        private readonly DbSet<UserDetail> userDetail;
        private readonly IMapper _mapper;

        public UserDetailRepository(DPizzaContext dbContext, IMapper mapper) : base(dbContext)
        {
            userDetail = dbContext.Set<UserDetail>();
            _mapper = mapper;
        }

        public async Task<UserDetail> GetProductByIdAsync(long id)
        {
            var query = await userDetail
                       .FirstOrDefaultAsync(a => a.Id == id);

            return query;
        }

        public async Task<PagenationResponseDto<UserDetailDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
        {
            var query = userDetail.OrderBy(p => p.CreatedDate).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.FirstName.Contains(name));
            }

            return await Paged(
                query.Select(p => new UserDetailDto(p)),
                pageNumber,
                pageSize);

        }
    }
}
