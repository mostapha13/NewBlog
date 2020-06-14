using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domains.Authors.Entities;
using Blog.Domains.Authors.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Blog.DataAccessQueries.Authors.Repositories
{
    public class AuthorRepositoryQuery: IAuthorRepositoryQuery
    {
        private readonly SqlConnection _db;

        public AuthorRepositoryQuery(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration["ConnectionStrings:QueryConnection"]);
        }

        #region GetAllAuthor

        public async Task<IEnumerable<Author>> GetAllAuthor()
        {
            return await _db.QueryAsync<Author>("SELECT * FROM dbo.Authors");
        }

        #endregion

        #region GetAuthorById

        public async Task<Author> GetAuthorById(int id)
        {
            return await _db.QuerySingleOrDefaultAsync<Author>("SELECT * FROM dbo.Authors WHERE id=@id", new { @id = id });
        }


        #endregion

        #region IsEmailExist
        public async Task<bool> IsEmailExist(string email)
        {
            var emailExist
                = await _db.QueryFirstOrDefaultAsync<int>("SELECT count(*) FROM dbo.Authors WHERE Email=@email", new { @email = email.Trim().ToLower() });

            return emailExist > 0 ? true : false;
        }
        #endregion

        #region IsUserNameExist
        public async Task<bool> IsUserNameExist(string userName)
        {
            var userNameExist = await _db.QueryFirstOrDefaultAsync<int>("SELECT count(*) FROM dbo.Authors WHERE UserName=@userName", new { @userName = userName });

            return userNameExist > 0 ? true : false;
        } 
        #endregion
    }
}