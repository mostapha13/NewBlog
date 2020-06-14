using Blog.DataAccessCommand.Context;
using Blog.DataAccessCommands.Authors.Repositories;
using Blog.DataAccessCommands.Comments.Repositories;
using Blog.DataAccessCommands.Posts.Repositories;
using Blog.DataAccessCommands.Subjects.Repositories;
using Blog.Domains.Authors.Repositories;
using Blog.Domains.Comments.Repositories;
using Blog.Domains.Commons;
using Blog.Domains.Posts.Repositories;
using Blog.Domains.Subjects.Repositories;
using System.Threading.Tasks;


namespace Blog.DataAccessCommands.Commons
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NewBlogContext _db;
        private IAuthorRepositoryCommand _authorRepositoryCommand;
        private IPostRepositoryCommand _postRepositoryCommand;
        private ICommentRepositoryCommand _commentRepositoryCommand;
        private ISubjectRepositoryCommand _subjectRepositoryCommand;

        public UnitOfWork(NewBlogContext db)
        {
            _db = db;


        }

        #region AuthorRepositoryCommand

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

        #endregion

        #region PostRepositoryCommand

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

        #endregion

        #region CommentRepositoryCommand

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


        #endregion
        
        #region SubjectRepositoryCommand

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

        #endregion
        
        #region Save

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _db?.Dispose();
        }

        #endregion
    }
}