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
            var order = new DPizza.Domain.Models.Entities.Order(request.UserId, request.OrderNumber, request.OrderTypeId, request.OrderStatusId, request.AdditionalInstruction
                ,request.AdditionalNotes, request.DeliveryPerson,request.LocationLink, request.IsOrderForSelf, request.BranchId, request.OrderRecipient, request.OrderDetails);

            await orderRepository.AddAsync(order);
            await unitOfWork.SaveChangesAsync();

            // 2. Generate the order number using the inserted order ID
            var generatedOrderNumber = GenerateOrderNumber(order.Id);

            // 3. Update the order record with the generated order number
            order.OrderNumber = generatedOrderNumber;
            await unitOfWork.SaveChangesAsync(); // Assuming unitOfWork includes changes made to the order


            return new BaseResult<long>(order.Id);
        }

        private string GenerateOrderNumber(long orderId)
        {
            // Logic to generate order number using orderId
            // Example: Concatenate a prefix with orderId
            return "ORD-" + orderId.ToString().PadLeft(6, '0'); // Example format: ORD-000001
        }


    }
}
