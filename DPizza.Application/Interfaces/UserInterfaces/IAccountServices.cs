using DPizza.Application.DTOs.Account.Requests;
using DPizza.Application.DTOs.Account.Responses;
using DPizza.Application.Wrappers;
using System.Threading.Tasks;

namespace DPizza.Application.Interfaces.UserInterfaces
{
    public interface IAccountServices
    {
        Task<BaseResult<AuthenticationResponse>> RegisterAccount(CreateUserRequest model);
        Task<BaseResult<string>> RegisterGostAccount();
        Task<BaseResult> ChangePassword(ChangePasswordRequest model);
        Task<BaseResult> ChangeUserName(ChangeUserNameRequest model);
        Task<BaseResult<AuthenticationResponse>> Authenticate(AuthenticationRequest request);
        Task<BaseResult<AuthenticationResponse>> AuthenticateByUserName(string username);

    }
}
