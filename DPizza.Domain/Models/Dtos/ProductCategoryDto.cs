using DPizza.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPizza.Domain.Models.Dtos
{
    public class ProductCategoryDto
    {
        public ProductCategoryDto()
        {
        }
        public ProductCategoryDto(ProductCategory productCategory)
        {
            Id = productCategory.Id;
            Name = productCategory.Name;
            Description = productCategory.Description;
            IsDeleted = productCategory.IsDeleted;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
