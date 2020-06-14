using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Authors.Commands;
using Blog.Domains.Authors.Entities;
using Blog.Domains.Authors.Repositories;
using Blog.Domains.Commons;
using Blog.Domains.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.ApplicationServices.Authors.Commands.Handlers
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, ResultStatus>
    {
    

        private readonly IUnitOfWork _db;

        public AddAuthorCommandHandler(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<ResultStatus> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {

            Author author = new Author()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email
            };


            await _db.AuthorRepositoryCommand.AddAuthor(author);
            await _db.Save();
            return ResultStatus.Success;
        }
    }
}