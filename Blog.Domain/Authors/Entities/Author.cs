using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domains.Common;
using Blog.Domains.Posts.Entities;

namespace Blog.Domains.Authors.Entities
{
    public class Author: BaseEntity
    {
        #region Propertise

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        #endregion

 


        #region Relations

        public virtual List<Post> Posts { get; set; }

        #endregion

    }
}