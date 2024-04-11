﻿using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Entities;
using MediatR;
using System.Collections.Generic;

namespace DPizza.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<BaseResult<long>>
    {
        public long ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
    }
}
