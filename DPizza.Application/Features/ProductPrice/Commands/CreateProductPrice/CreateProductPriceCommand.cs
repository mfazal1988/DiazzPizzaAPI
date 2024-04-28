using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using DPizza.Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace DPizza.Application.Features.ProductPrice.Commands.CreateProductPrice
{
    public class CreateProductPriceCommand : IRequest<BaseResult<long>>
    {
        public long ProductDetailId { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public decimal Price { get; set; }
        public bool IsCurrent { get; set; }

    }
}
