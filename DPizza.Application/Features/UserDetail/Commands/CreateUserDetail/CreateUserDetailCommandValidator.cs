using DPizza.Application.Features.Products.Commands.CreateProduct;
using DPizza.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.UserDetail.Commands.CreateUserDetail
{
    public class CreateUserDetailCommandValidator : AbstractValidator<CreateUserDetailCommand>
    {
        public CreateUserDetailCommandValidator(ITranslator translator)
        {
            RuleFor(p => p.UserId)
                .NotNull()
                .NotEmpty()
                .WithName(p => translator["UserId"]);

            RuleFor(p => p.UserTypeId)
                .NotNull()
                .NotEmpty()
                .WithName(p => translator["UserTypeId"]);

            RuleFor(p => p.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200)
                .WithName(p => translator["FirstName"]);

            RuleFor(p => p.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200)
                .WithName(p => translator["LastName"]);

            RuleFor(p => p.Address)
                .NotNull()
                .NotEmpty()
                .MaximumLength(500)
                .WithName(p => translator["Address"]);

            RuleFor(p => p.City)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .WithName(p => translator["City"]);

            RuleFor(p => p.ContactNumber)
               .NotNull()
               .NotEmpty()
               .MaximumLength(20)
               .WithName(p => translator["ContactNumber"]);
        }
    }
}
