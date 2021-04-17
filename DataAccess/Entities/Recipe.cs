using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class Recipe : EntityBase
    {
        public string ApiVersion { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<Version> Versions { get; set; }
    }
}
