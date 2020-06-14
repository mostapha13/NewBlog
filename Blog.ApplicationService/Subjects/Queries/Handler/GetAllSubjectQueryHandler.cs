using Blog.Domains.Subjects.Entities;
using Blog.Domains.Subjects.Queries;
using Blog.Domains.Subjects.Repositories;
using MediatR;
using Serilog;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.ApplicationServices.Subjects.Queries.Handler
{
    public class GetAllSubjectQueryHandler : IRequestHandler<GetAllSubjectQuery, IEnumerable<Subject>>
    {
        private readonly ISubjectRepositoryQuery _db;

        public GetAllSubjectQueryHandler(ISubjectRepositoryQuery db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Subject>> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
        {
            Log.Information("GetAllSubjectQuery");
            return await _db.GetAllSubject();
        }
    }
}