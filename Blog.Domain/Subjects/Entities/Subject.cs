using System.Collections.Generic;
using Blog.Domains.Commons;
using Blog.Domains.Posts.Entities;

namespace Blog.Domains.Subjects.Entities
{
    public class Subject:BaseEntity
    {
        #region Propertise

        public string Title { get; set; }


        #endregion


        #region Relations

        public virtual List<Post> Posts { get; set; }
        

        #endregion


    }
}