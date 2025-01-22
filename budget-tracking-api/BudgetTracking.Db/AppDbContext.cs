using BudgetTracking.Application;
using BudgetTracking.Application.Services;
using BudgetTracking.Domain.Models;
using BudgetTracking.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BudgetTracking.Db;

public class AppDbContext : DbContext, IAppDbContext
{
    private readonly IUserContext _userContext;

    public DbSet<User> Users { get; set; }

    public DbSet<SupCategory> SupCategories { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Expense> Expenses { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options, IUserContext userContext) : base(options)
    {
        _userContext = userContext;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(c => c.Id);
        modelBuilder.Entity<User>().Property(c => c.Email).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<User>().Property(c => c.Password).HasMaxLength(255);

        modelBuilder.Entity<SupCategory>().HasKey(c => c.Id);
        modelBuilder.Entity<SupCategory>().Property(c => c.Name).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<SupCategory>().Property(c => c.MetaDescription).IsRequired().HasMaxLength(255);

        modelBuilder.Entity<Category>().HasKey(c => c.Id);
        modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<Category>()
            .HasOne(s => s.SupCategory)
            .WithMany(c => c.Categories)
            .HasForeignKey(s => s.SupCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Expense>().HasKey(c => c.Id);
        modelBuilder.Entity<Expense>().Property(c => c.Note).HasMaxLength(255);
        modelBuilder.Entity<Expense>()
            .HasOne(s => s.Category)
            .WithMany(c => c.Expenses)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var trackedEntries = ChangeTracker.Entries<ITrackable>();
        foreach (var entry in trackedEntries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = _userContext.Id;
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedBy = _userContext.Id;
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
