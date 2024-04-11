using DPizza.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.DTOs.Account.Requests
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }

    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator(ITranslator translator)
        {
            RuleFor(x => x.Role)
                .NotEmpty().NotNull()
                .MinimumLength(4)
                .Must(BeSelectedRoles).WithMessage("Role must be 'Administrator', 'SalesPerson', 'DeliveryPerson' or 'Customer'.")
                .WithName(translator["Role"]);
        }

        private bool BeSelectedRoles(string name)
        {
            return name == "Administrator" || name == "SalesPerson" || name == "DeliveryPerson" || name == "Customer";
        }
    }

}
