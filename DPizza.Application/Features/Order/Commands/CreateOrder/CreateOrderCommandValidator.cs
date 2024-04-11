using DPizza.Application.Features.Products.Commands.CreateProduct;
using DPizza.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator(ITranslator translator)
        {

            RuleFor(p => p.UserId)
                .NotNull()
                .NotEmpty()                
                .WithName(p => translator["UserId"]);

            RuleFor(p => p.OrderNumber)
               .NotNull()
               .NotEmpty()
               .WithName(p => translator["OrderNumber"]);

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
