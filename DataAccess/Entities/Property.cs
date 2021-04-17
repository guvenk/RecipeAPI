namespace DataAccess
{
    public class Property : EntityBase
    {
        public string Value { get; set; }

        public long MetaItemId { get; set; }
        public MetaItem MetaItem { get; set; }

        public long VersionId { get; set; }
        public Version Version { get; set; }
    }
}
