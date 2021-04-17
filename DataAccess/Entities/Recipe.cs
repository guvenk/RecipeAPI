using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class Recipe : EntityBase
    {
        public string ApiVersion { get; set; }

        public int Status { get; set; }

        public DateTime CreateDate { get; set; }

        public List<Version> Versions { get; set; }
    }
}
