using System.Collections.Generic;
using Blog.Domains.Authors.Entities;
using Blog.Domains.Commons;
using Blog.Domains.Comments.Entities;
using Blog.Domains.Subjects.Entities;

namespace Blog.Domains.Posts.Entities
{
    public class Post:BaseEntity
    {
        #region Propertise
        public string Title { get; set; }
        public int SubjectId { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }

        #endregion



        #region Relations

        public virtual Author Author { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual Subject Subject { get; set; }

        #endregion
    }
}