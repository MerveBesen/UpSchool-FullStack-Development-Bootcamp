using MediatR;

namespace Application.Features.Orders.Queries.GetAll;

public class OrderGetAllQuery:IRequest<List<OrderGetAllDto>>
{
    public string Name { get; set; }

    public OrderGetAllQuery(string name)
    {
        Name = name;
    }
}