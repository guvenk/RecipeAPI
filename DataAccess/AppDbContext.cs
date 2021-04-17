using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Version> Versions { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MetaItem> MetaItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // to make table and column names start with lowercase character.
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(
                    $"{entityType.GetTableName().Substring(0, 1).ToLowerInvariant()}{entityType.GetTableName()[1..]}");


                foreach (var property in entityType.GetProperties())
                    property.SetColumnName(
                        $"{property.GetColumnName().Substring(0, 1).ToLowerInvariant()}{property.GetColumnName()[1..]}");
            }
        }
    }
}
