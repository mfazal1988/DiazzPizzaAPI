using DPizza.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.ProductCategory.Commands.DeleteProductCategory
{
    public class DeleteProductCategoryCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
