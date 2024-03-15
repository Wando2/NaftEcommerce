using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Naft.Domain.Entities;

namespace Naft.Infra.Data.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        // Title Value Object
        builder.OwnsOne(p => p.Title, title =>
        {
            title.Property(t => t.TitleName)
                .HasColumnName("Title")
                .HasMaxLength(100)
                .IsRequired();
        });

        // Description Value Object
        builder.OwnsOne(p => p.Description, description =>
        {
            description.Property(d => d.DescriptionText)
                .HasColumnName("Description")
                .HasMaxLength(1000)
                .IsRequired();
        });

        // Price Value Object
        builder.OwnsOne(p => p.Price, price =>
        {
            price.Property(p => p.Value)
                .HasColumnName("Price")
                .IsRequired();
        });

        // Quantity Value Object
        builder.OwnsOne(p => p.Quantity, quantity =>
        {
            quantity.Property(q => q.Value)
                .HasColumnName("Quantity")
                .IsRequired();
        });

        // Image Value Object
        builder.OwnsOne(p => p.Image, image =>
        {
            image.Property(i => i.Url)
                .HasColumnName("ImageUrl")
                .HasMaxLength(255);
        });

        builder.HasOne(p => p.Seller)
            .WithMany(s => s.Products)
            .HasForeignKey("SellerId");

        builder.HasMany(p => p.Categories)
            .WithMany(c => c.Products)
            .UsingEntity(j => j.ToTable("ProductCategories"));
        
        builder.HasMany(p => p.Categories)
            .WithMany(c => c.Products)
            .UsingEntity<Dictionary<string, object>>(
                "ProductCategory", // Name of the join table
                product => product.HasOne<Category>()
                    .WithMany()
                    .HasForeignKey("CategoryId")
                    .OnDelete(DeleteBehavior.Cascade), // Configure cascade delete as per your domain requirements
                category => category.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Cascade),
                joinEntity =>
                {
                    joinEntity.HasKey("ProductId", "CategoryId"); // Composite primary key for the join table
                });
    }
}