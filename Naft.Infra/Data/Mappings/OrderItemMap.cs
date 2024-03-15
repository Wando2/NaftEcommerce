using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Naft.Domain.Entities;

namespace Naft.Infra.Data.Mappings;

public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");

        builder.HasKey(oi => oi.Id);

        // Mapping for the direct reference to Product
        builder.HasOne(oi => oi.Product)
            .WithMany() // Assuming Product doesn't have a navigation property back to OrderItem; otherwise, specify it here
            .HasForeignKey("ProductId") // You need a ProductId property in OrderItem for this to work, or EF Core needs to be able to infer it
            .OnDelete(DeleteBehavior.Restrict); // Or another behavior as per your domain requirements

       
        builder.Property(oi => oi.Quantity)
            .IsRequired();

        builder.Property(oi => oi.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        
    }
}