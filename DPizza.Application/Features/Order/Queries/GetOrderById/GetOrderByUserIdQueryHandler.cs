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
    
    public class GetOrderByUserIdQueryHandler(IOrderRepository orderRepository,
        IProductRepository productRepository,
        IProductDetailRepository productDetailRepository,
         IPaymentRepository paymentRepository
        ) : IRequestHandler<GetOrderByUserIdQuery, PagedResponse<OrderDto>>
    {
        public async Task<PagedResponse<OrderDto>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
        {
            var result = await orderRepository.GetOrderByUserIdAsync(request.PageNumber, request.PageSize, request.UserId);

            foreach (var order in result.Data)
            {
                foreach (var orderDetail in order.OrderDetails)
                {
                    if (orderDetail.ProductDetailID > 0)
                    {
                        var product = await productRepository.GetProductByIdAsync(productDetailRepository.GetProductDetailByIdAsync(orderDetail.ProductDetailID).Result.ProductId);
                        orderDetail.Product = new ProductDto(product); // Assign the product to the Product property of each OrderDetailDto
                    }
                }

                var objList = new PaymentDto();
                order.Payments = objList.MapList(paymentRepository.GetPaymentByOrderIdAsync(order.Id));
            }

            return new PagedResponse<OrderDto>(result, request);
        }
    }


}
