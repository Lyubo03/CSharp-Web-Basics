namespace Suls
{
    using Microsoft.EntityFrameworkCore;
    using Suls.Models;
    using System.Reflection;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; }
        public DbSet<Commit> Commits { get; }
        public DbSet<Repository> Repositoriess { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(@"Server=DESKTOP-2RO7KG1\SQLEXPRESS;Database=SULS;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) =>
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}