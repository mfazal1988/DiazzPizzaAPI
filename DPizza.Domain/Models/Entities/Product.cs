using DPizza.Domain.Common;
using System.Collections.Generic;

namespace DPizza.Domain.Models.Entities
{
    public class Product : AuditableBaseEntity
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Product()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Product(long productCategoryId,string name, string description, string imagePath, List<ProductDetail> productDetails)
        {
            ProductCategoryId = productCategoryId;
            Name = name;
            Description = description;
            ImagePath = imagePath;
            //ProductCategory = productCategory;
            ProductDetails = productDetails;
        }
        public long ProductCategoryId { get;  set; }        
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string ImagePath { get;  set; }
       // public virtual ProductCategory ProductCategory { get; private set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; } 

        public void Update(long id, long productCategoryId, string name, string description, string imagePath, bool isDeleted)
        {
            Id = id;
            ProductCategoryId = productCategoryId;
            Name = name;
            Description = description;
            ImagePath = imagePath;
            //ProductCategory = productCategory;
            //ProductDetails = productDetails;
            IsDeleted = isDeleted;
        }
    }
}
