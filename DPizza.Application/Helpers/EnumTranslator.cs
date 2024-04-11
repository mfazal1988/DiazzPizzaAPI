using DPizza.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Helpers
{
    public static class EnumTranslator
    {
        public static ProductDto CrustAndVarientTypeString(ProductDto product)
        {
            if (product != null)
            {
                // Apply business logic to update crust type
                switch (product.ProductDetails.FirstOrDefault().CrustTypeId)
                {
                    case Domain.Enums.EnumCrustType.Pan:
                        product.ProductDetails.FirstOrDefault().CrustType = "Pan";
                        break;
                    case Domain.Enums.EnumCrustType.Sausage:
                        product.ProductDetails.FirstOrDefault().CrustType = "Sausage";
                        break;
                    default:
                        product.ProductDetails.FirstOrDefault().CrustType = "Unknown";
                        break;
                }

                switch (product.ProductDetails.FirstOrDefault().ProductVarientId)
                {
                    case Domain.Enums.EnumProductVarient.Regular:
                        product.ProductDetails.FirstOrDefault().ProductVariant = "Regular";
                        break;
                    case Domain.Enums.EnumProductVarient.Medium:
                        product.ProductDetails.FirstOrDefault().ProductVariant = "Medium";
                        break;
                    case Domain.Enums.EnumProductVarient.Large:
                        product.ProductDetails.FirstOrDefault().ProductVariant = "Large";
                        break;
                    case Domain.Enums.EnumProductVarient.Pcs6:
                        product.ProductDetails.FirstOrDefault().ProductVariant = "Pcs6";
                        break;
                    case Domain.Enums.EnumProductVarient.Pcs12:
                        product.ProductDetails.FirstOrDefault().ProductVariant = "Pcs12";
                        break;
                    default:
                        product.ProductDetails.FirstOrDefault().CrustType = "Unknown";
                        break;
                }
            }
            return product;
        }
    }
}
