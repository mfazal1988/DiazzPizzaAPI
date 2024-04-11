using DPizza.Application.Features.Order.Commands.DeleteOrder;
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

namespace DPizza.Application.Features.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<DeleteOrderCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetByIdAsync(request.Id);

            if (order is null)
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            orderRepository.Delete(order);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult();
        }
    }
}
