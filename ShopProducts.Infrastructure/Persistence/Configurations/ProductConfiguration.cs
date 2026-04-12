using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopProducts.Domain.Entities;

namespace ShopProducts.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(prop => prop.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasIndex(prop => prop.Name).IsUnique();
        
        builder.Property(prop => prop.Description)
            .HasMaxLength(2000);

        builder.ComplexProperty(prop => prop.Money, action =>
        {
            action.Property(e => e.Currency).HasColumnName("Price");
            action.Property(e => e.Mount).HasColumnName("Amount");
        });
        
        builder.ComplexProperty(prop => prop.QuantityInventory, action =>
        {
            action.Property(e => e.Value).HasColumnName("Inventory");
        });
    }
}