using Application.Common.Interfaces;
using Application.Common.Models.Product;
using Domain.Entities;
using MediatR;

namespace Application.Features.Orders.Queries.GetAll;

public class OrderGetAllQueryHandler:IRequestHandler<OrderGetAllQuery,List<OrderGetAllDto>>
{

    private readonly IApplicationDbContext _applicationDbContext;

    public OrderGetAllQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<List<OrderGetAllDto>> Handle(OrderGetAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private IEnumerable<OrderGetAllDto> mapOrdersGetAllDtos(List<Order> orders)
    {
        List<OrderGetAllDto> orderGetAllDtos = new List<OrderGetAllDto>();
        foreach (var order in orders)
        {

            yield return new OrderGetAllDto()
            {
                Name = order.Name,
                ProductAmount = order.ProductAmount,
                ProductCrawlTypeName = ProductCrawlTypeDto.ConvertToProductCrawlTypeName(order.ProductCrawlType),
                TotalProductAmount = order.TotalProductAmount,
            };
        }
    }
}