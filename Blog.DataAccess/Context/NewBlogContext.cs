using Blog.Domains.Authors.Entities;
using Blog.Domains.Comments.Entities;
using Blog.Domains.Posts.Entities;
using Blog.Domains.Subjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataAccessCommands.Context
{
    public class NewBlogContext : DbContext
    {
        public NewBlogContext(DbContextOptions<NewBlogContext> options) : base(options)
        {

        }



        public DbSet<Author> Authors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }





        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);



        }

        #endregion
    }
}