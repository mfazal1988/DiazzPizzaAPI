using DPizza.Application.Features.Products.Commands.CreateProduct;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Interfaces;
using DPizza.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPizza.Domain.Models.Entities;
using System.Threading;

namespace DPizza.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, BaseResult<long>>
    {
        public async Task<BaseResult<long>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new DPizza.Domain.Models.Entities.Order(request.UserId, request.OrderNumber, request.OrderTypeId, request.OrderRecipientId, request.OrderStatusId, request.AdditionalInstruction
                ,request.AdditionalNotes, request.LocationLink, request.IsOrderForSelf, request.BranchId, request.OrderRecipient, request.OrderDetails);

            await orderRepository.AddAsync(order);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult<long>(order.Id);
        }
    }
}
