using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Blog.Domains.Subjects.Entities;
using Blog.Domains.Subjects.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Blog.DataAccessQueries.Subjects.Repositories
{
    public class SubjectRepositoryQuery: ISubjectRepositoryQuery
    {
        private readonly SqlConnection _db;
      

        public SubjectRepositoryQuery(IConfiguration configuration)
        {
            _db =new SqlConnection(configuration["ConnectionStrings:QueryConnection"]) ;
        }
        
        public async Task<IEnumerable<Subject>> GetAllSubject()
        {
            return await _db.QueryAsync<Subject>("SELECT * FROM dbo.Subjects");
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            return await _db.QuerySingleOrDefaultAsync<Subject>("SELECT * FROM dbo.Subjects WHERE id=@id",new{@id=id});
        }
    }
}