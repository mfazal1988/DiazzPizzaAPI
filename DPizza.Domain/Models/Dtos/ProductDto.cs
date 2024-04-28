using AutoMapper;
using DPizza.Domain.Models.Entities;
using System.Collections.Generic;

namespace DPizza.Domain.Models.Dtos
{
    public class ProductDto
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ProductDto()
        {
            
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ProductDto(Product product)
        {
            Id = product.Id;
            ProductCategoryId = product.ProductCategoryId; 
            Name = product.Name;
            Description = product.Description;
            ImagePath = product.ImagePath;
            IsDeleted = product.IsDeleted;

            var objList = new ProductDetailDto();
            ProductDetails = objList.MapList(product.ProductDetails ?? new List<ProductDetail>());
        }
        public long Id { get; set; }
        public long ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
        //public ProductCategory ProductCategory { get; set; }
        public List<ProductDetailDto> ProductDetails { get; set; }
    }
}
