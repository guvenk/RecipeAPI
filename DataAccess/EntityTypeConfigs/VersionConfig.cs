using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace DataAccess.EntityTypeConfigs
{
    public class VersionConfig : IEntityTypeConfiguration<Version>
    {
        public void Configure(EntityTypeBuilder<Version> builder)
        {
            builder.ToTable(nameof(Version), "dbo");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.HasKey(x => x.Id)
                .IsClustered();

            builder.Property(x => x.Rating)
                .IsRequired(false);

            builder.Property(x => x.CreatedDate)
                .HasColumnType("datetime2(2)")
                .IsRequired();

            builder.HasMany(x => x.Properties)
                  .WithOne()
                  .HasForeignKey(x => x.VersionId)
                  .HasPrincipalKey(x => x.Id)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Comments)
                 .WithOne()
                 .HasForeignKey(x => x.VersionId)
                 .HasPrincipalKey(x => x.Id)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Medias)
                 .WithOne()
                 .HasForeignKey(x => x.VersionId)
                 .HasPrincipalKey(x => x.Id)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
