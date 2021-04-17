using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityTypeConfigs
{
    public class MediaConfig : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.ToTable(nameof(Media), "dbo");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.HasKey(x => x.Id)
                .IsClustered();

            builder.Property(x => x.RawUrl)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.Type)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(x => x.StorageSource)
               .HasMaxLength(128)
               .IsRequired();

            builder.Property(x => x.CreatedDate)
                .HasColumnType("datetime2(2)")
                .IsRequired();
        }
    }
}
