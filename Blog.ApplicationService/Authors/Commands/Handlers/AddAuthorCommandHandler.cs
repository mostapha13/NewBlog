﻿using Blog.Domains.Authors.Commands;
using Blog.Domains.Authors.Entities;
using Blog.Domains.Commons;
using Blog.Domains.Enums;
using MediatR;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

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
            Log.Information("AddAuthor"); ;

            Author author = new Author()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email
            };


            await _db.AuthorRepositoryCommand.AddAuthor(author);
            await _db.Save();

            Log.Information("SuccessAddAuthor"); ;

            return ResultStatus.Success;

        }
    }
}