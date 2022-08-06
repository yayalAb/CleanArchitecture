using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Product> Products { get; }
    DbSet<Order> Orders { get; }
    DbSet<Driver> Drivers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
