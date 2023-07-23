using Domain.Entities;
using Domain.Enums;

namespace Domain.Dtos;

public class OrderDto
{

    public Guid Id { get; set; }
    public string Name { get; set; }

    public int ProductAmount { get; set; }

    public int TotalProductAmount { get; set; }

    public ProductCrawlType ProductCrawlType { get; set; }

    public static OrderDto MapFromOrder(Order order)
    {
        return new OrderDto()
        {
            Id = order.Id,
            Name = order.Name,
            ProductAmount = order.ProductAmount,
            
            ProductCrawlType = order.ProductCrawlType,
        };
    }
}