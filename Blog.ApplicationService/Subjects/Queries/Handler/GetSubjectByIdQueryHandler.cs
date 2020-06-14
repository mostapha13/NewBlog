using Blog.Domains.Subjects.Entities;
using Blog.Domains.Subjects.Queries;
using Blog.Domains.Subjects.Repositories;
using MediatR;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.ApplicationServices.Subjects.Queries.Handler
{
    public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, Subject>
    {
        private readonly ISubjectRepositoryQuery _db;

        public GetSubjectByIdQueryHandler(ISubjectRepositoryQuery db)
        {
            _db = db;
        }
        public async Task<Subject> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            Log.Information("GetSubjectByIdQuery " + request.Id);
            return await _db.GetSubjectById(request.Id);
        }
    }
}