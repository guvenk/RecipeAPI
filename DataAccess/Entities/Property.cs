using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class Property : EntityBase
    {
        public string Value { get; set; }

        public long MetaItemId { get; set; }
        public MetaItem MetaItem { get; set; }

        public long RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
