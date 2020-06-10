using Blog.Domains.Comments.Entities;
using FluentValidation;

namespace Blog.ApplicationServices.Comments.Validation
{
    public class CommentValidator:AbstractValidator<Comment>
    {

        public CommentValidator()
        {
            RuleFor(c => c.Text)
                .NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(1000).WithMessage("{PropertyName} باید حداکثر 1000 کارکتر باشد  ")
                .WithName("متن");
        }
        
    }
}