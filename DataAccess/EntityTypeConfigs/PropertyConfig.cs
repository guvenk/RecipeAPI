using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace DataAccess.EntityTypeConfigs
{
    public class PropertyConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable(nameof(Property), "dbo");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.HasKey(x => x.Id)
                .IsClustered();

            builder.Property(x => x.Value)
                .HasMaxLength(512)
                .IsRequired();

            builder.Property(x => x.MetaItemId)
                .IsRequired();
        }
    }
}
