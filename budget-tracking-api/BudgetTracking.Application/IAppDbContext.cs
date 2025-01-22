using BudgetTracking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracking.Application;

public interface IAppDbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<SupCategory> SupCategories { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Expense> Expenses { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken ct);
}
