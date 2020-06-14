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
    

        private readonly IUnitOfWork _command;

        public AddAuthorCommandHandler(IUnitOfWork command)
        {
            _command = command;
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


            await _command.AuthorRepositoryCommand.AddAuthor(author);
            await _command.Save();
            return ResultStatus.Success;
        }
    }
}