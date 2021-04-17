using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class Version : EntityBase
    {
        public int Rating { get; set; }

        public List<Property> Properties { get; set; }

        public List<Media> Medias { get; set; }

        public List<Comment> Comments { get; set; }

        public long RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}