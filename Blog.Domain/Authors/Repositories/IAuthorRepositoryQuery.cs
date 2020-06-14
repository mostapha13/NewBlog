using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domains.Authors.Entities;

namespace Blog.Domains.Authors.Repositories
{
    public interface IAuthorRepositoryQuery
    {
      Task<IEnumerable<Author>> GetAllAuthor();
      Task<Author> GetAuthorById(int id);

      Task<bool> IsEmailExist(string email);

      Task<bool> IsUserNameExist(string userName);

    }
}