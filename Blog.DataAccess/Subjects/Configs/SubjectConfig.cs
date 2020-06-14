using Blog.Domains.Subjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccessCommands.Subjects.Configs
{
    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.Property(s => s.Title).IsRequired().HasMaxLength(250);


            builder.HasMany(s => s.Posts)
                .WithOne(p => p.Subject)
                .HasForeignKey(s => s.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}