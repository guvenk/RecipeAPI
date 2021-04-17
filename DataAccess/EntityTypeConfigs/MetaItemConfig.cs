using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace DataAccess.EntityTypeConfigs
{
    public class MetaItemConfig : IEntityTypeConfiguration<MetaItem>
    {
        public void Configure(EntityTypeBuilder<MetaItem> builder)
        {
            builder.ToTable(nameof(MetaItem), "dbo");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.HasKey(x => x.Id)
                .IsClustered();

            // to help for the performance of queries that filters by Name
            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(x => x.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(x => x.DataType)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasData(new List<MetaItem>
            {
                new MetaItem
                {
                    Id = 1L,
                    Name = "Title",
                    DataType = "string",
                },
                new MetaItem
                {
                    Id = 2L,
                    Name = "Description",
                    DataType = "string",
                },
                new MetaItem
                {
                    Id = 3L,
                    Name = "OriginCountry",
                    DataType = "string",
                },
                new MetaItem
                {
                    Id = 4L,
                    Name = "Category",
                    DataType = "string",
                },
                new MetaItem
                {
                    Id = 5L,
                    Name = "Ingredient",
                    DataType = "string",
                },
                new MetaItem
                {
                    Id = 6L,
                    Name = "IsSpicy",
                    DataType = "bool",
                }
            });
        }
    }
}
