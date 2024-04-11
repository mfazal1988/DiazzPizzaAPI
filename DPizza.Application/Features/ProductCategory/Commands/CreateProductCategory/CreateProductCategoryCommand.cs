using DPizza.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.ProductCategory.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommand : IRequest<BaseResult<long>>
    { 
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
