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
        IAuthorRepositoryCommand RepositoryCommand { get;}

        IPostRepositoryCommand PostRepositoryCommand { get;}
        IPostRepositoryQuery PostRepositoryQuery { get;}

        ICommentRepositoryCommand CommentRepositoryCommand { get;}
        ICommentRepositoryQuery CommentRepositoryQuery { get;}

        ISubjectRepositoryCommand SubjectRepositoryCommand { get;}
        ISubjectRepositoryQuery SubjectRepositoryQuery { get;}

        Task Save();
    }
}