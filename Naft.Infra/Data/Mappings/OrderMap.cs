using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Naft.Domain.Entities;

namespace Naft.Infra.Data.Mappings;

public class OrderMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.Number)
            .HasColumnName("OrderNumber")
            .HasMaxLength(100)
            .IsRequired();
        

        // Mapping for the Date field
        builder.Property(o => o.Date)
            .IsRequired();

        // Mapping for the Status field, assuming EOrderStatus is an enum
        builder.Property(o => o.Status)
            .HasConversion<string>()
            .IsRequired();

        // Mapping for Seller and Buyer references
        builder.HasOne(o => o.Seller)
            .WithMany() // If Seller has a navigation property to Orders, specify it here
            .HasForeignKey("SellerId") // Ensure you have SellerId as a property if not, EF needs to be able to infer it
            .OnDelete(DeleteBehavior.Restrict); // Or any other behavior as per your requirements

        builder.HasOne(o => o.Buyer)
            .WithMany() // If Buyer has a navigation property to Orders, specify it here
            .HasForeignKey("BuyerId") // Ensure you have BuyerId as a property if not, EF needs to be able to infer it
            .OnDelete(DeleteBehavior.Restrict); // Or any other behavior as per your requirements

        // Mapping for the OrderItems collection
        builder.HasMany(o => o._Items)
            .WithOne() // Assuming OrderItem does not have a navigation property back to Order; otherwise specify it
            .HasForeignKey("OrderId") // You might need to add OrderId in OrderItem for this to work
            .OnDelete(DeleteBehavior.Cascade); // Ensures OrderItems are deleted when an Order is deleted

       
    }
}