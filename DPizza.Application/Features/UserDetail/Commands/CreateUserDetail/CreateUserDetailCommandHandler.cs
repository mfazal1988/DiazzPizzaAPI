using DPizza.Application.Features.Products.Commands.CreateProduct;
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

namespace DPizza.Application.Features.UserDetail.Commands.CreateUserDetail
{
    public class CreateUserDetailCommandHandler(IUserDetailRepository userDetailRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateUserDetailCommand, BaseResult<long>>
    {
        public async Task<BaseResult<long>> Handle(CreateUserDetailCommand request, CancellationToken cancellationToken)
        {
            var product = new DPizza.Domain.Models.Entities.UserDetail(request.UserId, request.UserTypeId, request.FirstName, request.LastName, request.Address
                                ,request.City, request.ContactNumber);

            await userDetailRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult<long>(product.Id);
        }
    }
}
