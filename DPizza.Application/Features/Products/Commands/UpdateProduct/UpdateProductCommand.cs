using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Entities;
using MediatR;
using System.Collections.Generic;

namespace DPizza.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
        public long ProductCategoryId { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
    }
}
