using Blog.Domains.Authors.Repositories;
using Blog.Domains.Comments.Repositories;
using Blog.Domains.Commons;
using Blog.Domains.Posts.Repositories;
using Blog.Domains.Subjects.Repositories;
using System.Threading.Tasks;
using Blog.DataAccessCommand.Context;
using Blog.DataAccessCommands.Authors.Repositories;
using Blog.DataAccessCommands.Comments.Repositories;
using Blog.DataAccessCommands.Posts.Repositories;
using Blog.DataAccessCommands.Subjects.Repositories;
using Blog.DataAccessQueries.Comments.Repositories;
using Blog.DataAccessQueries.Posts.Repositories;
using Blog.DataAccessQueries.Subjects.Repositories;
using Microsoft.Extensions.Configuration;

namespace Blog.DataAccessCommands.Commons
{
    public class UnitOfWork : IUnitOfWork
    {
        private NewBlogContext _db;
      

        public UnitOfWork(NewBlogContext db)
        {
            _db = db;
           
        }

        private IAuthorRepositoryCommand _authorRepositoryCommand;

        public IAuthorRepositoryCommand AuthorRepositoryCommand
        {
            get
            {
                if (_authorRepositoryCommand == null)
                {
                    _authorRepositoryCommand = new AuthorRepositoryCommand(_db);
                }

                return _authorRepositoryCommand;
            }
        }

        private IAuthorRepositoryCommand _repositoryCommand;

        public IAuthorRepositoryCommand RepositoryCommand
        {
            get
            {

                if (_repositoryCommand == null)
                {
                    _repositoryCommand = new AuthorRepositoryCommand(_db);
                }

                return _repositoryCommand;
            }
        }


        private IPostRepositoryCommand _postRepositoryCommand;
        public IPostRepositoryCommand PostRepositoryCommand
        {
            get
            {
                if (_postRepositoryCommand == null)
                {
                    _postRepositoryCommand = new PostRepositoryCommand();
                }

                return _postRepositoryCommand;
            }
        }

        private IPostRepositoryQuery _postRepositoryQuery;

        public IPostRepositoryQuery PostRepositoryQuery
        {
            get
            {
                if (_postRepositoryQuery == null)
                {
                    _postRepositoryQuery = new PostRepositoryQuery();
                }

                return _postRepositoryQuery;

            }
        }


        private ICommentRepositoryCommand _commentRepositoryCommand;

        public ICommentRepositoryCommand CommentRepositoryCommand
        {
            get
            {
                if (_commentRepositoryCommand == null)
                {
                    _commentRepositoryCommand = new CommentRepositoryCommand();
                }

                return _commentRepositoryCommand;

            }
        }

        private ICommentRepositoryQuery _commentRepositoryQuery;

        public ICommentRepositoryQuery CommentRepositoryQuery
        {
            get
            {
                if (_commentRepositoryQuery == null)
                {
                    _commentRepositoryQuery = new CommentRepositoryQuery();
                }

                return _commentRepositoryQuery;
            }
        }


        private ISubjectRepositoryCommand _subjectRepositoryCommand;

        public ISubjectRepositoryCommand SubjectRepositoryCommand
        {
            get
            {
                if (_subjectRepositoryCommand == null)
                {
                    _subjectRepositoryCommand = new SubjectRepositoryCommand();
                }

                return _subjectRepositoryCommand;
            }
        }



        private ISubjectRepositoryQuery _subjectRepositoryQuery;

        public ISubjectRepositoryQuery SubjectRepositoryQuery
        {
            get
            {
                if (_subjectRepositoryQuery == null)
                {
                    _subjectRepositoryQuery = new SubjectRepositoryQuery();
                }

                return _subjectRepositoryQuery;
            }
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
          _db?.Dispose();
        }
    }
}