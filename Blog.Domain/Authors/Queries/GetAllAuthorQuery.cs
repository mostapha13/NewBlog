using System.Collections.Generic;
using Blog.Domains.Authors.Entities;
using MediatR;

namespace Blog.Domains.Authors.Queries
{
    public class GetAllAuthorQuery:IRequest<IEnumerable<Author>>
    {
   
    }
}