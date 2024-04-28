using DPizza.Application.DTOs;
using DPizza.Domain.Models.Dtos;
using DPizza.Domain.Models.Entities;
using System.Threading.Tasks;

namespace DPizza.Application.Interfaces.Repositories
{
    public interface IBranchDetailRepository : IGenericRepository<BranchDetail>
    {
        Task<PagenationResponseDto<BranchDetailDto>> GetPagedListAsync(int pageNumber, int pageSize, string city);

        Task<BranchDetail> GetBranchDetailByIdAsync(long id);
    }
}
