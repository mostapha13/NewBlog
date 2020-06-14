using Blog.Domains.Subjects.Entities;
using FluentValidation;

namespace Blog.ApplicationServices.Subjects.Validations
{
    public class SubjectValidator : AbstractValidator<Subject>
    {
        public SubjectValidator()
        {
            RuleFor(s => s.Title).NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("{PropertyName} باید حداکثر 250 کارکتر باشد  ")
                .WithName("نام گروه");
        }
    }
}