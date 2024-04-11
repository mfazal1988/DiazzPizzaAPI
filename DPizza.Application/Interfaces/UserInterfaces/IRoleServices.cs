using DPizza.Application.DTOs.Account.Requests;
using DPizza.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Interfaces.UserInterfaces
{
    public interface IRoleServices
    {
        Task<BaseResult> CreateRole(CreateRoleRequest model);
    }
}
