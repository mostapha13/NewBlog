using System;
using System.Threading.Tasks;
using Blog.Domains.Authors.Repositories;
using Blog.Domains.Comments.Repositories;
using Blog.Domains.Posts.Repositories;
using Blog.Domains.Subjects.Repositories;

namespace Blog.Domains.Commons
{
    public interface IUnitOfWork:IDisposable
    {
        IAuthorRepositoryCommand AuthorRepositoryCommand { get;}
      
        IPostRepositoryCommand PostRepositoryCommand { get;}
      
        ICommentRepositoryCommand CommentRepositoryCommand { get;}
    
        ISubjectRepositoryCommand SubjectRepositoryCommand { get;}
     
        Task Save();
    }
}