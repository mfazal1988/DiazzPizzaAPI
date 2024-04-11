using DPizza.Application.Features.Products.Commands.DeleteProduct;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Interfaces;
using DPizza.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPizza.Application.Helpers;
using System.Threading;

namespace DPizza.Application.Features.ProductCategory.Commands.DeleteProductCategory
{
    public class DeleteProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<DeleteProductCategoryCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var product = await productCategoryRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            productCategoryRepository.Delete(product);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult();
        }
    }
}
