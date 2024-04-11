using DPizza.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPizza.Domain.Models.Dtos
{
    public class ProductDetailDto
    {
        public ProductDetailDto()
        {
        }

        public ProductDetailDto(ProductDetail productDetail)
        {
            Id = productDetail.Id;
            ProductId = productDetail.ProductId;
            CrustTypeId = (Enums.EnumCrustType)productDetail.CrustTypeId;
            ProductVarientId = (Enums.EnumProductVarient)productDetail.ProductVarientId;
            //ProductPriceId = productDetail.ProductPriceId;
            IsDeleted = productDetail.IsDeleted;
            //Product = productDetail.Product;
            ProductPrice = new ProductPriceDto(productDetail.ProductPrice);
        }

        public List<ProductDetailDto> MapList(ICollection<ProductDetail> productDetailList)
        {
            ProductDetailDto productDetailDto = new ProductDetailDto();
            List<ProductDetailDto> ProductDetailDtoList = new List<ProductDetailDto>();
            if (productDetailList != null)
            { 
                foreach (var productDetail in productDetailList)
                {
                    productDetailDto = new ProductDetailDto(productDetail);
                    ProductDetailDtoList.Add(productDetailDto);
                }
            }
            return ProductDetailDtoList;
        }
        public long Id { get; set; }
        public long ProductId { get; set; }
        public Enums.EnumCrustType CrustTypeId { get; set; }
        public Enums.EnumProductVarient ProductVarientId { get; set; }
        public string CrustType { get; set; }
        public string ProductVariant { get; set; }
       
        public bool IsDeleted { get; set; }
       
        public ProductPriceDto ProductPrice { get; set; }
        
    }
}
