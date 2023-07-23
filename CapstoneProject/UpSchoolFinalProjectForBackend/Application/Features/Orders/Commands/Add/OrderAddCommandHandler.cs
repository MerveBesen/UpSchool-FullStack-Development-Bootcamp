using Application.Common.Interfaces;
using Application.Common.Models.Product;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Orders.Commands.Add;

public class OrderAddCommandHandler:IRequestHandler<OrderAddCommand,Response<Guid>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public OrderAddCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Response<Guid>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
    {
        var order = new Order()
        {
            Name = request.ProductCrawlTypeName,
            ProductAmount = request.ProductAmount,
            ProductCrawlType = ProductCrawlTypeDto.ConvertToProductCrawlType(request.ProductCrawlTypeName),
            CreatedOn = DateTimeOffset.Now,
        };

        await _applicationDbContext.Orders.AddAsync(order, cancellationToken);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new Response<Guid>($"The new order named \"{request.Name}\" was successfully added", order.Id);
    }
}