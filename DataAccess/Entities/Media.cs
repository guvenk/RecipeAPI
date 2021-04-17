using System;

namespace DataAccess
{
    public class Media : EntityBase
    {
        public string RawUrl { get; set; }
        public string Type { get; set; }

        public string StorageSource { get; set; }

        public DateTime CreatedDate { get; set; }

        public long VersionId { get; set; }
        public Version Version { get; set; }
    }
}