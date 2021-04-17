using System;
using System.Collections.Generic;

namespace Models
{
    public class RecipeDto
    {
        public long Id { get; set; }

        public string ApiVersion { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<VersionDto> Versions { get; set; }
    }
}
