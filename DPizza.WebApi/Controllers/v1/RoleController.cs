using DPizza.Application.DTOs.Account.Requests;
using DPizza.Application.Interfaces.UserInterfaces;
using DPizza.Application.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DPizza.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class RoleController(IRoleServices roleServices) : BaseApiController
    {
        [HttpPost]
        public async Task<BaseResult> CreateRole(CreateRoleRequest request)
            => await roleServices.CreateRole(request);
    }
}
