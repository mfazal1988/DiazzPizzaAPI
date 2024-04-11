using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.ProductCategory.Queries.GetProductCategoryById
{
    public class GetProductCategoryByIdQuery : IRequest<BaseResult<ProductCategoryDto>>
    {
        public long Id { get; set; }
    }
}
