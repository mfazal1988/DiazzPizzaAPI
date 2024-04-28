using DPizza.Application.Features.ProductCategory.Queries.GetProductCategoryById;
using DPizza.Application.Helpers;
using DPizza.Application.Interfaces;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
 
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.BranchDetail.Queries.GetBranchDetailById
{
 
    public class GetBranchDetailByIdQueryHandler(IBranchDetailRepository productCategoryRepository, ITranslator translator) : IRequestHandler<GetBranchDetailByIdQuery, BaseResult<BranchDetailDto>>
    {
        public async Task<BaseResult<BranchDetailDto>> Handle(GetBranchDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var productCategory = await productCategoryRepository.GetBranchDetailByIdAsync(request.Id);

            if (productCategory is null)
            {
                return new BaseResult<BranchDetailDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            var result = new BranchDetailDto(productCategory);

            return new BaseResult<BranchDetailDto>(result);
        }

    }
}
