using Blog.Domains.Posts.Entities;
using FluentValidation;

namespace Blog.ApplicationServices.Posts.Validation
{
    public class PostValidator:AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(p => p.Text).NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("{PropertyName} باید حداکثر 250 کارکتر باشد  ")
                .WithName("عنوان");

            RuleFor(p => p.Title).NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("{PropertyName} باید حداکثر 250 کارکتر باشد  ")
                .WithName("متن");

            RuleFor(p => p.AuthorId).NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .WithName("نام نویسنده");

            RuleFor(p=>p.SubjectId).NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .WithName("گروه");



            
        }
    }
}