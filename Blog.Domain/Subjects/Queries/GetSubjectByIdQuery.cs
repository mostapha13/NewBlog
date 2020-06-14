using Blog.Domains.Subjects.Entities;
using MediatR;

namespace Blog.Domains.Subjects.Queries
{
    public class GetSubjectByIdQuery:IRequest<Subject>
    {
        public int Id { get; set; }

        public GetSubjectByIdQuery(int id)
        {
            Id = id;
        }
    }
}