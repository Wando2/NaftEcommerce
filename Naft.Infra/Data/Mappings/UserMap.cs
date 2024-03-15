using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Naft.Domain.Entities;

namespace Naft.Infra.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn(1, 1);
        
            builder.OwnsOne(u => u.Name, name =>
            {
                name.Property(n => n.FirstName)
                    .HasColumnName("FirstName")
                    .HasMaxLength(100)
                    .IsRequired();

                name.Property(n => n.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(100)
                    .IsRequired();
            });
            
            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.EmailAddress)
                    .HasColumnName("Email")
                    .HasMaxLength(100)
                    .IsRequired();
            });
            
            builder.OwnsOne(u => u.Password, password =>
            {
                password.Property(p => p.PasswordHashText)
                    .HasColumnName("PasswordHash")
                    .HasMaxLength(100)
                    .IsRequired();
            });
            
            builder.OwnsOne(u => u.Slug, slug =>
            {
                slug.Property(s => s.SlugText)
                    .HasColumnName("Slug")
                    .HasMaxLength(100)
                    .IsRequired();
            });
            
            builder.HasMany(x => x.Products)
                .WithOne()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);
           
            builder
                .HasIndex(x => x.Slug, "IX_User_Slug")
                .IsUnique();
            
            
    }
}