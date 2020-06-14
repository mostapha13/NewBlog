using System.Collections.Generic;
using Blog.Domains.Subjects.Entities;
using MediatR;

namespace Blog.Domains.Subjects.Queries
{
    public class GetAllSubjectQuery:IRequest<IEnumerable<Subject>>
    {
        
    }
}