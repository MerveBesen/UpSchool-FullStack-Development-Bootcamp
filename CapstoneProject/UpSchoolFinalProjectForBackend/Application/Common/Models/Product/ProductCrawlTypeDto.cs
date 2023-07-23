using Domain.Enums;

namespace Application.Common.Models.Product;

public class ProductCrawlTypeDto
{
    public ProductCrawlType ProductCrawlType { get; set; }
    
    public string ProductCrawlTypeName { get; set; }

    public static ProductCrawlType ConvertToProductCrawlType(string ProductCrawlTypeName)
    {
        switch (ProductCrawlTypeName)
        {
            case "all": return ProductCrawlType.All;
            
            case "ondiscount": return ProductCrawlType.OnDiscount;
            
            case "nondiscount": return ProductCrawlType.NonDiscount;
            
            default:
                throw new Exception("Product crawl type couldn't identified.");
        }
    }
    
    public static string ConvertToProductCrawlTypeName(ProductCrawlType ProductCrawlType)
    {
        switch (ProductCrawlType)
        {
            case ProductCrawlType.All: return "All";
            
            case ProductCrawlType.OnDiscount: return "OnDiscount";
            
            case ProductCrawlType.NonDiscount: return "NonDiscount";
            
            default:
                throw new Exception("Product crawl type couldn't identified.");
        }
    }
}