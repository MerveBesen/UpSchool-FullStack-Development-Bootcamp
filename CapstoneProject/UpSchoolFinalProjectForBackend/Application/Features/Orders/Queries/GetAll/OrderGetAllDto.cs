namespace Application.Features.Orders.Queries.GetAll;

public class OrderGetAllDto
{
    public string Name { get; set; }

    public int ProductAmount { get; set; }

    public int TotalProductAmount { get; set; }

    public string ProductCrawlTypeName { get; set; }
}