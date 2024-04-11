using DPizza.Application.Helpers;
using DPizza.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.DTOs.Account.Requests
{
    public class CreateRoleRequest
    {
        public string Name { get; set; }
    }

    public class CreateRoleRequestValidator : AbstractValidator<CreateRoleRequest>
    {
        public CreateRoleRequestValidator(ITranslator translator)
        {
            RuleFor(x => x.Name)
                .NotEmpty().NotNull()
                .MinimumLength(4)                
                .WithName(translator["Name"]);
        }
    }
}
