using DPizza.Application.Interfaces;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, BaseResult<long>>
    {
        //public async Task<BaseResult<long>> Handle2(CreateProductCommand request, CancellationToken cancellationToken)
        //{
        //    var product = new Product(request.ProductCategoryId, request.Name, request.Description, request.ImagePath, null);

        //    await productRepository.AddAsync(product);
        //    await unitOfWork.SaveChangesAsync();

        //    return new BaseResult<long>(product.Id);
        //}

        public async Task<BaseResult<long>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.ProductCategoryId, request.Name, request.Description, request.ImagePath, request.ProductDetails);

            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult<long>(product.Id);
        }
    }
}
