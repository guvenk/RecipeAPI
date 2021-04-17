using System;

namespace Models
{
    public class CommentDto
    {
        public string Text { get; set; }

        public long? UserId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
