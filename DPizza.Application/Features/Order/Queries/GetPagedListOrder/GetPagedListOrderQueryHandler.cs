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
using DPizza.Application.Features.Products.Queries.GetPagedListProduct;

namespace DPizza.Application.Features.Order.Queries.GetPagedListOrder
{
    public class GetPagedListOrderQueryHandler(IOrderRepository orderRepository, 
        IProductRepository productRepository, 
        IProductDetailRepository productDetailRepository,
        IPaymentRepository paymentRepository
        ) 
        : IRequestHandler<GetPagedListOrderQuery, PagedResponse<OrderDto>>
    {
        public async Task<PagedResponse<OrderDto>> Handle(GetPagedListOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await orderRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.OrderNumber);

            var objList = new PaymentDto();
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

                order.Payments = objList.MapList(paymentRepository.GetPaymentByOrderIdAsync(order.Id));
            }

            return new PagedResponse<OrderDto>(result, request);
        }
    }
}
