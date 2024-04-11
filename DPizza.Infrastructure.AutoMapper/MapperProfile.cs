using AutoMapper;
using DPizza.Domain.Models.Dtos;
using DPizza.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Infrastructure.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<ProductDetailDto, ProductDetail>();
            CreateMap<ProductDetail, ProductDetailDto>();

            //CreateMap<List<ProductDetail>, List<ProductDetailDto>>();
            //CreateMap<List<ProductDetailDto>, List<ProductDetail>>();
        }
    }
}
