using System;
using System.Collections.Generic;

namespace Models
{
    public class VersionDto
    {
        public int? Rating { get; set; }

        public List<PropertyDto> Properties { get; set; }

        public List<MediaDto> Medias { get; set; }

        public List<CommentDto> Comments { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
