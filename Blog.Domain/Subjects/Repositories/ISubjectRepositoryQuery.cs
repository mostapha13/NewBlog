using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domains.Subjects.Entities;

namespace Blog.Domains.Subjects.Repositories
{
    public interface ISubjectRepositoryQuery
    {
        Task<IEnumerable<Subject>> GetAllSubject();

        Task<Subject> GetSubjectById(int id);
    }
}