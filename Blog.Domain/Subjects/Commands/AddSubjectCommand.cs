﻿using Blog.Domains.Enums;
using MediatR;

namespace Blog.Domains.Subjects.Commands
{
    public class AddSubjectCommand:IRequest<ResultStatus>
    {
        #region Propertise
        public string Title { get; set; }

        #endregion
    }
}