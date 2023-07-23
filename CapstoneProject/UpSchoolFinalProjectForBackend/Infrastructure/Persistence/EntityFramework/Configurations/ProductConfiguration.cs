using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Configurations;

public class ProductConfiguration:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // ID
        builder.HasKey(x => x.Id);

        //Name
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.HasIndex(x => x.Name);


        //Picture
        builder.Property(x => x.Picture).IsRequired();


        //IsOnSale
        builder.Property(x => x.IsOnSale).IsRequired();
        

        //Price



        //Sale


        // CreatedOn
        builder.Property(x => x.CreatedOn).IsRequired();


        builder.ToTable("Products");
    }
}