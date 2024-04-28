using DPizza.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPizza.Domain.Models.Entities
{
    public class ProductCategory : AuditableBaseEntity
    {
        private ProductCategory()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ProductCategory(string name, string description)
        {
            //Id = id;
            Name = name;
            Description = description;
            //IsDeleted = isDeleted;
        }
        public string Name { get;  set; }
        public string Description { get;  set; }
       // public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public void Update(long id, string name, string description, bool isDeleted)
        {
            Id = id;
            Name = name;
            Description = description;
            IsDeleted = isDeleted;
        }
    }
}
