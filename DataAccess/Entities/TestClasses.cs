using System.Collections.Generic;

namespace DataAccess
{
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
