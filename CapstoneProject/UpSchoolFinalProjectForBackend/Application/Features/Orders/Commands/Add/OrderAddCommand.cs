using Domain.Common;
using MediatR;

namespace Application.Features.Orders.Commands.Add;

public class OrderAddCommand:IRequest<Response<Guid>>
{
    public string Name { get; set; }

    public int ProductAmount { get; set; }

    public string ProductCrawlTypeName { get; set; }
}