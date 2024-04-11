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
using DPizza.Domain.Models.Entities;

namespace DPizza.Application.Features.UserDetail.Commands.DeleteUserDetail
{
    public class DeleteUserDetailCommandHandler(IUserDetailRepository productRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<DeleteUserDetailCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(DeleteUserDetailCommand request, CancellationToken cancellationToken)
        {
            var userDetail = await productRepository.GetByIdAsync(request.Id);

            if (userDetail is null)
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            productRepository.Delete(userDetail);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult();
        }
    }
}
