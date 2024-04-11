
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Interfaces;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DPizza.Application.Features.Products.Commands.CreateProduct;
using System.Reflection;

namespace DPizza.Application.Features.ProductCategory.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommandHandler(IProductCategoryRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCategoryCommand, BaseResult<long>>
    {
        public async Task<BaseResult<long>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Models.Entities.ProductCategory(request.Name,  request.Description);

            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult<long>(product.Id);
        }
    }    
}
