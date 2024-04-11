using DPizza.Application.Interfaces.UserInterfaces;
using DPizza.Application.Interfaces;
using DPizza.Domain.Settings;
using DPizza.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPizza.Application.DTOs.Account.Requests;
using DPizza.Application.DTOs.Account.Responses;
using DPizza.Application.Wrappers;
using DPizza.Application.Helpers;

namespace DPizza.Infrastructure.Identity.Services
{
    public class RoleServices(RoleManager<ApplicationRole> roleManager, ITranslator translator) : IRoleServices
    {
        public async Task<BaseResult> CreateRole(CreateRoleRequest model)
        {
            if (!await roleManager.RoleExistsAsync(model.Name))
            {
                var identityResult = await roleManager.CreateAsync(new ApplicationRole(model.Name));
                if (identityResult.Succeeded)
                {
                    return new BaseResult();
                }
                return new BaseResult(identityResult.Errors.Select(p => new Error(ErrorCode.ErrorInIdentity, p.Description)));
            }
            return new BaseResult(new Error(ErrorCode.ErrorInIdentity, translator.GetString(TranslatorMessages.RoleMessages.Role_already_exists(model.Name)), nameof(model.Name)));
        }
    }
}
