using Blog.Domains.Authors.Entities;
using MediatR;

namespace Blog.Domains.Authors.Queries
{
    public class GetAuthorByIdQuery:IRequest<Author>
    {
        public int Id { get; set; }

        public GetAuthorByIdQuery(int id)
        {
            Id = id;
        }
    }
}