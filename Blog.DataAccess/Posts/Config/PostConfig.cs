using Blog.Domains.Posts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommand.Posts.Config
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.AuthorId).IsRequired();
            builder.Property(p => p.SubjectId).IsRequired();
            builder.Property(p => p.Text).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(250);


            builder.HasMany(p => p.Comments)
                .WithOne(p => p.Post)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}