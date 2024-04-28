using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Entities;
using MediatR;
using System.Collections.Generic;

namespace DPizza.Application.Features.ProductPrice.Commands.UpdateProductPrice
{
    public class UpdateProductPriceCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
        public long ProductDetailId { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public decimal Price { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsDeleted { get; set; }
    }
}
