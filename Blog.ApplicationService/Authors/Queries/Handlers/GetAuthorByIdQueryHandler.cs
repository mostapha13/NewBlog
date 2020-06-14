﻿using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Authors.Entities;
using Blog.Domains.Authors.Queries;
using Blog.Domains.Authors.Repositories;
using MediatR;
using Serilog;

namespace Blog.ApplicationServices.Authors.Queries.Handlers
{
    public class GetAuthorByIdQueryHandler:IRequestHandler<GetAuthorByIdQuery,Author>
    {
        private IAuthorRepositoryQuery _query;

        public GetAuthorByIdQueryHandler(IAuthorRepositoryQuery query)
        {
            _query = query;
        }

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        { 
            Log.Information("GetAuthorById"+request.Id);

           return await _query.GetAuthorById(request.Id);
        }
    }
}