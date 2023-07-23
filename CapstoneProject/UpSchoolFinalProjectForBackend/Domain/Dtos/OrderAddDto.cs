using Domain.Enums;

namespace Domain.Dtos;

public class OrderAddDto
{
    public string Name { get; set; }

    public int ProductAmount { get; set; }

    public ProductCrawlType ProductCrawlType { get; set; }
    
    public string ConnectionId { get; set; }
}