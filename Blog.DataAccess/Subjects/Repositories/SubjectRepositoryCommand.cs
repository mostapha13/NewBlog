using System.Threading.Tasks;
using Blog.DataAccessCommand.Context;
using Blog.Domains.Subjects.Entities;
using Blog.Domains.Subjects.Repositories;

namespace Blog.DataAccessCommands.Subjects.Repositories
{
    public class SubjectRepositoryCommand: ISubjectRepositoryCommand
    {
        private readonly NewBlogContext _db;

        public SubjectRepositoryCommand(NewBlogContext db)
        {
            _db = db;
        }
        public async Task AddSubject(Subject subject)
        {
          await _db.Subjects.AddAsync(subject);
        }
    }
}