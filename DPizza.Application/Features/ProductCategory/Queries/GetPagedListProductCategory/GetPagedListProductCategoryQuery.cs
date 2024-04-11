using DPizza.Application.Parameters;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.ProductCategory.Queries.GetPagedListProductCategory
{
    public class GetPagedListProductCategoryQuery : PagenationRequestParameter, IRequest<PagedResponse<ProductCategoryDto>>
    {
        public string Name { get; set; }
    }
}
