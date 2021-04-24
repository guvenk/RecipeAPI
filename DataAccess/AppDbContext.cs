using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;

namespace DataAccess
{


    public class AppDbContext : DbContext
    {

        // many to many
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        // TPH
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<RssBlog> RssBlogs { get; set; }

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

            // TPH
            modelBuilder.Entity<Blog>()
                .HasDiscriminator(x => x.BlogType)
                .HasValue<Blog>(BlogType.Normal)
                .HasValue<RssBlog>(BlogType.Rss);
        }

        public class Blog
        {
            public int BlogId { get; set; }
            public string Url { get; set; }
            public BlogType BlogType { get; set; }
        }
        public enum BlogType
        {
            Normal,
            Rss
        }

        public class RssBlog : Blog
        {
            public string RssUrl { get; set; }
        }

        public class Post
        {
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }

            public ICollection<Tag> Tags { get; set; }
        }

        public class Tag
        {
            public int TagId { get; set; }

            public ICollection<Post> Posts { get; set; }
        }
    }
}
