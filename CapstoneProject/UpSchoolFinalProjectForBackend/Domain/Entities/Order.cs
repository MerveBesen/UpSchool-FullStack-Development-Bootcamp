using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Order:EntityBase<Guid>
{
    public string Name { get; set; }

    public int ProductAmount { get; set; }

    public int TotalProductAmount { get; set; }

    public ProductCrawlType ProductCrawlType { get; set; }

    public ICollection<OrderEvent> OrderEvents { get; set; }

    public ICollection<Product> Products { get; set; }

}