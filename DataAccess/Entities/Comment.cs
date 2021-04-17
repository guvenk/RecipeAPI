using System;

namespace DataAccess
{
    public class Comment : EntityBase
    {
        public string Text { get; set; }

        public long? UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public long VersionId { get; set; }
        public Version Version { get; set; }
    }
}