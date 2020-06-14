using System;
using System.Threading.Tasks;
using Blog.Domains.Authors.Entities;

namespace Blog.Domains.Authors.Repositories
{
    public interface IAuthorRepositoryCommand
    {
        Task AddAuthor(Author author);

      
    }
}