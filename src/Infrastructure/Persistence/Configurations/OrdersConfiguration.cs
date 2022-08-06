using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class OrdersConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(n => n.OrderedBy)
            .HasMaxLength(200)
            .IsRequired();
    }
}