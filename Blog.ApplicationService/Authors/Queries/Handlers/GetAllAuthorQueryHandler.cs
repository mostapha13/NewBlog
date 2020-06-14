using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Authors.Entities;
using Blog.Domains.Authors.Queries;
using Blog.Domains.Authors.Repositories;
using MediatR;

namespace Blog.ApplicationServices.Authors.Queries.Handlers
{
    public class GetAllAuthorQueryHandler:IRequestHandler<GetAllAuthorQuery,IEnumerable<Author>>
    {

        private IAuthorRepositoryQuery _query;

        public GetAllAuthorQueryHandler(IAuthorRepositoryQuery query)
        {
            _query = query;
        }

        public async Task<IEnumerable<Author>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            return await _query.GetAllAuthor();

           
        }
    }
}