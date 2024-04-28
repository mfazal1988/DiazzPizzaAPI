using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using DPizza.Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace DPizza.Application.Features.ProductDetail.Commands.CreateProductDetail
{
    public class CreateProductDetailCommand : IRequest<BaseResult<long>>
    {
        public CreateProductDetailCommand()
        {
            ProductPrice =null;
        }

        public long ProductId { get; set; }
        public int CrustTypeId { get; set; }
        public int ProductVarientId { get; set; }
        public Domain.Models.Entities.ProductPrice ProductPrice { get; set; }

    }
}
