using Blog.Domains.Commons;
using Blog.Domains.Enums;
using Blog.Domains.Subjects.Commands;
using Blog.Domains.Subjects.Entities;
using MediatR;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.ApplicationServices.Subjects.Commands.Handlers
{
    public class AddSubjectCommandHandler : IRequestHandler<AddSubjectCommand, ResultStatus>
    {
        private readonly IUnitOfWork _db;

        public AddSubjectCommandHandler(IUnitOfWork db)
        {
            _db = db;
        }


        public async Task<ResultStatus> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            Log.Information("AddSubjectCommand");
            Subject subject = new Subject()
            {
                Title = request.Title
            };
            await _db.SubjectRepositoryCommand.AddSubject(subject);
            await _db.Save();

            Log.Information("Success AddSubjectCommand");
            return ResultStatus.Success;
        }
    }
}