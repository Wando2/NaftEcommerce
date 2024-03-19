using Microsoft.EntityFrameworkCore;
using Naft.Domain.Entities;
using Naft.Domain.ValueObjects;
using Naft.Infra.Data.Mappings;


namespace Naft.Infra.Data;


public class NaftContextData : DbContext
{
    public  DbSet<User> Users { get; init; }
    public DbSet<Product> Products { get; init; }
    public DbSet<Category> Categories { get; init; }
    public  DbSet<Order> Orders { get; init; }
    public  DbSet<OrderItem> OrderItems { get; init; }
    
    public NaftContextData(DbContextOptions<NaftContextData> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        
        modelBuilder.ApplyConfiguration(new ProductMap());
        
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new OrderMap());
        modelBuilder.ApplyConfiguration(new OrderItemMap());
        
       
        
        
        
    }
}