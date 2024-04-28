using DPizza.Application.Features.Order.Queries.GetPagedListOrder;
using DPizza.Application.Helpers;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Interfaces;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DPizza.Application.Features.Products.Queries.GetProductById;

namespace DPizza.Application.Features.Order.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler(IOrderRepository orderRepository,
        ITranslator translator, IProductRepository productRepository,
        IProductDetailRepository productDetailRepository,
         IPaymentRepository paymentRepository
        )
        : IRequestHandler<GetOrderByIdQuery, BaseResult<OrderDto>>
    {
        public async Task<BaseResult<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetOrderByIdAsync(request.Id);

            if (order is null)
            {
                return new BaseResult<OrderDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            var result = new OrderDto(order);

            foreach (var orderDetail in result.OrderDetails)
            {
                if (orderDetail.ProductDetailID > 0)
                {
                    var product = await productRepository.GetProductByIdAsync(productDetailRepository.GetProductDetailByIdAsync(orderDetail.ProductDetailID).Result.ProductId);
                    orderDetail.Product = new ProductDto(product); // Assign the product to the Product property of each OrderDetailDto
                }
            }

            var objList = new PaymentDto();
            result.Payments = objList.MapList(paymentRepository.GetPaymentByOrderIdAsync(order.Id));

            return new BaseResult<OrderDto>(result);
        }
    }
}
