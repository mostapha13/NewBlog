using Blog.Domains.Common;
using Blog.Domains.Posts.Entities;

namespace Blog.Domains.Comments.Entities
{
    public class Comment:BaseEntity
    {
        #region Propertise

        public int PostId { get; set; }

        public string Text { get; set; }

        #endregion


        #region Relations

        public virtual Post Post { get; set; }

        #endregion


    }
}