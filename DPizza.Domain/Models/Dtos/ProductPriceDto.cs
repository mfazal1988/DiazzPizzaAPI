using DPizza.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPizza.Domain.Models.Dtos
{
    public class ProductPriceDto
    {
        public ProductPriceDto()
        {

        }

        public ProductPriceDto(ProductPrice productPrice)
        {
            Id = productPrice.Id;
            ValidFrom = productPrice.ValidFrom;
            ValidTo = productPrice.ValidTo;
            Price = productPrice.Price;
            IsCurrent = productPrice.IsCurrent;
            IsDeleted = productPrice.IsDeleted;
        }
        public long Id { get; set; }
        public string ValidFrom { get;  set; }
        public string ValidTo { get;  set; }
        public decimal Price { get;  set; }
        public bool IsCurrent { get;  set; }
        public bool IsDeleted { get;  set;}
    }
}