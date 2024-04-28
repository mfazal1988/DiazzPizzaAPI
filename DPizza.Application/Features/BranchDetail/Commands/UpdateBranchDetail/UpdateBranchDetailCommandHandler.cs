using DPizza.Application.Helpers;
using DPizza.Application.Interfaces;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.BranchDetail.Commands.UpdateBranchDetail
{
    public class UpdateBranchDetailCommandHandler(IBranchDetailRepository productRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<UpdateBranchDetailCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(UpdateBranchDetailCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            product.Update(request.Id , request.Number, request.Address1, request.Address2, request.City, request.ContactNumber, request.IsDeleted);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult();
        }
    }
}
