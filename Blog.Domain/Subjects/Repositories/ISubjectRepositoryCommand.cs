using System.Threading.Tasks;
using Blog.Domains.Subjects.Entities;

namespace Blog.Domains.Subjects.Repositories
{
    public interface ISubjectRepositoryCommand
    {
        Task AddSubject(Subject subject);
    }
}