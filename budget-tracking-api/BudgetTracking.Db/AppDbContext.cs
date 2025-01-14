using BudgetTracking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracking.Db;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    // public DbSet<SupCategory> SupCategories { get; set; }

    // public DbSet<Category> Categories { get; set; }

    // public DbSet<Expense> Expenses { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(c => c.Id);
        modelBuilder.Entity<User>().Property(c => c.Email).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<User>().Property(c => c.Password).HasMaxLength(255);

        // modelBuilder.Entity<SupCategory>().HasKey(c => c.Id);
        // modelBuilder.Entity<SupCategory>().Property(c => c.Name).IsRequired().HasMaxLength(255);
        // modelBuilder.Entity<SupCategory>().Property(c => c.MetaDescription).IsRequired().HasMaxLength(255);
        //
        // modelBuilder.Entity<Category>().HasKey(c => c.Id);
        // modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(255);
        // modelBuilder.Entity<Category>()
        //     .HasOne(s => s.SupCategory)
        //     .WithMany(c => c.Categories)
        //     .HasForeignKey(s => s.SupCategoryId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // modelBuilder.Entity<Expense>().HasKey(c => c.Id);
        // modelBuilder.Entity<Expense>().Property(c => c.Note).HasMaxLength(255);
        // modelBuilder.Entity<Expense>()
        //     .HasOne(s => s.Category)
        //     .WithMany()
        //     .HasForeignKey(e => e.CategoryId)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}
