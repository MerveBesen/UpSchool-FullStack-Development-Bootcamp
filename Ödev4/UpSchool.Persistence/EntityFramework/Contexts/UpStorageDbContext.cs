using Microsoft.EntityFrameworkCore;
using UpSchool.Domain.Entities;
using UpSchool.Persistence.EntityFramework.Configurations;
using UpSchool.Persistence.EntityFramework.Seeders;

namespace UpSchool.Persistence.EntityFramework.Contexts;

public class UpStorageDbContext:DbContext
{
    public DbSet<Account> Accounts { get; set; }

    public UpStorageDbContext(DbContextOptions<UpStorageDbContext>options):base(options)
    {
        
        
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        
        
        modelBuilder.ApplyConfiguration(new AccountSeeder());
        
        base.OnModelCreating(modelBuilder);
        
    }
}