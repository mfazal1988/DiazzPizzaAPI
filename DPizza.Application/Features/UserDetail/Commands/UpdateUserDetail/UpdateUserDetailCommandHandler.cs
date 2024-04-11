using DPizza.Application.Features.Products.Commands.UpdateProduct;
using DPizza.Application.Helpers;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Interfaces;
using DPizza.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DPizza.Application.Features.UserDetail.Commands.UpdateUserDetail
{
    public class UpdateUserDetailCommandHandler(IUserDetailRepository userDetailRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<UpdateUserDetailCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(UpdateUserDetailCommand request, CancellationToken cancellationToken)
        {
            var product = await userDetailRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            product.Update(request.Id, request.UserId, request.UserTypeId, request.FirstName, request.LastName, request.Address,
                request.City,request.ContactNumber,request.IsDeleted);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult();
        }
    }
}
