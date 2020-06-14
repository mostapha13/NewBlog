using Blog.Domains.Authors.Entities;
using Blog.Domains.Authors.Queries;
using Blog.Domains.Authors.Repositories;
using MediatR;
using Serilog;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.ApplicationServices.Authors.Queries.Handlers
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, IEnumerable<Author>>
    {

        private readonly IAuthorRepositoryQuery _query;

        public GetAllAuthorQueryHandler(IAuthorRepositoryQuery query)
        {
            _query = query;
        }

        public async Task<IEnumerable<Author>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            Log.Information("GetAllAuthorQuery");
            return await _query.GetAllAuthor();



        }
    }
}