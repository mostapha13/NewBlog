using Blog.Domains.Comments.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommands.Comments.Configs
{
    public class CommentConfig:IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c=>c.Text).IsRequired().HasMaxLength(500);



            


        }



    }
}