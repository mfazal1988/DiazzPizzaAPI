using DPizza.Application.DTOs.Account.Requests;
using DPizza.Application.DTOs.Account.Responses;
using DPizza.Application.Wrappers;
using System.Threading.Tasks;

namespace DPizza.Application.Interfaces.UserInterfaces
{
    public interface IGetUserServices
    {
        Task<PagedResponse<UserDto>> GetPagedUsers(GetAllUsersRequest model);
    }
}
