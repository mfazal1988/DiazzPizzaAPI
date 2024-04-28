using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Entities;
using MediatR;
using System.Collections.Generic;

namespace DPizza.Application.Features.ProductDetail.Commands.UpdateProductDetail
{
    public class UpdateProductDetailCommand : IRequest<BaseResult>
    {
        //public UpdateProductDetailCommand()
        //{
        //    ProductPrice = null;
        //}
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int CrustTypeId { get; set; }
        public int ProductVarientId { get; set; }
        public bool IsDeleted { get; set; }
        //public Domain.Models.Entities.ProductPrice ProductPrice { get; set; }
    }
}
