using Blog.DataAccessCommands.Context;
using Blog.Domains.Authors.Entities;
using Blog.Domains.Authors.Repositories;
using System.Threading.Tasks;

namespace Blog.DataAccessCommands.Authors.Repositories
{
    public class AuthorRepositoryCommand : IAuthorRepositoryCommand
    {


        private readonly NewBlogContext _db;

        public AuthorRepositoryCommand(NewBlogContext db)
        {
            _db = db;
        }


        #region AddAuthor

        public async Task AddAuthor(Author author)
        {

            await _db.Authors.AddAsync(author);


        }

        #endregion

    }
}