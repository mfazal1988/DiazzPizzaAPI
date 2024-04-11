using DPizza.Application.Features.Products.Commands.UpdateProduct;
using DPizza.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator(ITranslator translator)
        {

            RuleFor(p => p.UserId)
                .NotNull()
                .NotEmpty()
                .WithName(p => translator["UserId"]);

            RuleFor(p => p.OrderTypeId)
               .NotNull()
               .NotEmpty()
               .WithName(p => translator["OrderTypeId"]);

            RuleFor(p => p.OrderStatusId)
               .NotNull()
               .NotEmpty()
               .WithName(p => translator["OrderStatusId"]);

            RuleFor(x => x.BranchId)
               .NotNull()
               .NotEmpty()
               .WithName(p => translator["BranchId"]);

        }
    }
}
