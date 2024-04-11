using DPizza.Application.Features.Products.Queries.GetProductById;
using DPizza.Application.Helpers;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Interfaces;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.UserDetail.Queries.GetUserDetailById
{
    public class GetUserDetailByIdQueryHandler(IUserDetailRepository userDetailRepository, ITranslator translator) : IRequestHandler<GetUserDetailByIdQuery, BaseResult<UserDetailDto>>
    {
        public async Task<BaseResult<UserDetailDto>> Handle(GetUserDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var userDetail = await userDetailRepository.GetProductByIdAsync(request.Id);

            if (userDetail is null)
            {
                return new BaseResult<UserDetailDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            var result = new UserDetailDto(userDetail);

            return new BaseResult<UserDetailDto>(result);
        }
    }
}
