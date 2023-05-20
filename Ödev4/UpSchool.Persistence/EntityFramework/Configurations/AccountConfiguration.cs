using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpSchool.Domain.Entities;

namespace UpSchool.Persistence.EntityFramework.Configurations;

public class AccountConfiguration:IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        // ID
        builder.HasKey(x => x.Id);
        
        // Title
        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(150);       // Sınırlama vermek için HasMaxLenght kullanılır. Title kısmına 150 karakterden fazla girilmemesi için.
        // builder.HasIndex(x => x.Title);
        builder.HasIndex(x => new { x.Title, x.UserName });         // Hem title hem de username kısmında arama yapmak için ikisi için de indexleme işlemini tek bir seferde yapar.
        
        // UserName
        builder.Property(x => x.UserName).IsRequired();
        builder.Property(x => x.UserName).HasMaxLength(100); 
         
        // Password
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(100);
         
        // Url
        builder.Property(x => x.Url).IsRequired(false);      //Url kısmı gelmeyedebilir bu nedenle false atandığında zorunlu olmadığı anlamına gelir.
        builder.Property(x => x.Url).HasMaxLength(100); 

        // IsFavourite
        builder.Property(x => x.IsFavourite).IsRequired();

        // CreatedOn
        builder.Property(x => x.CreatedOn).IsRequired();

        // LastModifiedOn
        builder.Property(x => x.LastModifiedOn).IsRequired(false);

        builder.ToTable("Accounts");        // Table isimleri çoğul verilir.

    }
}