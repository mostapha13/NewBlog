using Blog.Domains.Authors.Commands;
using Blog.Domains.Authors.Repositories;
using Blog.Domains.Enums;
using MediatR;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.ApplicationServices.Authors.Commands.Behaviors
{
    public class AddAuthorBehavior<T, TR> : IPipelineBehavior<AddAuthorCommand, ResultStatus>

    {

        private readonly IAuthorRepositoryQuery _read;


        public AddAuthorBehavior(IAuthorRepositoryQuery read)
        {
            _read = read;

        }

        public async Task<ResultStatus> Handle(AddAuthorCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<ResultStatus> next)
        {



            if (await _read.IsEmailExist(request.Email.Trim().ToLower()))
            {
                Log.Error("EmailExist " + request.Email.Trim().ToLower());
                return ResultStatus.EmailExist;
            }



            if (await _read.IsUserNameExist(request.UserName.Trim().ToLower()))
            {
                Log.Error("UserNameExist " + request.UserName.Trim().ToLower());

                return ResultStatus.UserNameExist;
            }

            return await next();
        }

    }
}