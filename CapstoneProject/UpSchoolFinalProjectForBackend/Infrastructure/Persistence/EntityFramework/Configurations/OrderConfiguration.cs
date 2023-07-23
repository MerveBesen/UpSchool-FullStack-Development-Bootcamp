using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Configurations;

public class OrderConfiguration:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // ID
        builder.HasKey(x => x.Id);
        
        
        // Name
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(250);

        // ProductAmount
        builder.Property(x => x.ProductAmount).IsRequired();


        // TotalProductAmount
        builder.Property(x => x.TotalProductAmount).IsRequired();
        

        // ProductCrawlType
        builder.Property(x => x.ProductCrawlType).IsRequired();
        
        
        // CreatedOn
        builder.Property(x => x.CreatedOn).IsRequired();


        builder.ToTable("Orders");

    }
}