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

namespace DPizza.Application.Features.Order.Commands.UpdateOrder
{
    public class UpdateOrderStatusCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<UpdateOrderStatusCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetByIdAsync(request.Id);

            if (order is null)
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            order.UpdateOrderStatus(request.Id,  request.OrderStatusId);
                
            await unitOfWork.SaveChangesAsync();

            return new BaseResult();
        }
    }
}
