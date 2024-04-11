using DPizza.Application.Features.Products.Commands.UpdateProduct;
using DPizza.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.UserDetail.Commands.UpdateUserDetail
{
    public class UpdateUserDetailCommandValidator : AbstractValidator<UpdateUserDetailCommand>
    {
        public UpdateUserDetailCommandValidator(ITranslator translator)
        {
            RuleFor(p => p.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .WithName(p => translator["FirstName"]);

            RuleFor(p => p.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .WithName(p => translator["LastName"]);

            RuleFor(p => p.Address)
                .NotNull()
                .NotEmpty()
                .MaximumLength(500)
                .WithName(p => translator["Address"]);

            RuleFor(x => x.City)
                .MaximumLength(100)
                .WithName(translator["City"]);

            RuleFor(x => x.ContactNumber)
                .MaximumLength(100)
                .WithName(translator["ContactNumber"]);
        }
    }
}
