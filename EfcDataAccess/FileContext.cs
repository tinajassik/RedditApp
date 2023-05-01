using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class FileContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/Reddit.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().Property(post => post.Title).HasMaxLength(30);
        modelBuilder.Entity<Post>().Property(post => post.Content).HasMaxLength(10000);
    }
}