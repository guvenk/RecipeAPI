using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityTypeConfigs
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable(nameof(Comment), "dbo");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.HasKey(x => x.Id)
                .IsClustered();

            builder.Property(x => x.Text)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired(false); // it is null if its made by an anonymous user

            builder.Property(x => x.CreatedDate)
                .HasColumnType("datetime2(2)")
                .IsRequired();
        }
    }
}
