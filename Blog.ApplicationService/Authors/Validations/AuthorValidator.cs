using Blog.Domains.Authors.Entities;
using FluentValidation;

namespace Blog.ApplicationServices.Authors.Validations
{
    public class AuthorValidator:AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("{PropertyName} باید حداکثر 250 کارکتر باشد  ")
                .WithName("نام");

            RuleFor(a => a.LastName).NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("{PropertyName} باید حداکثر 250 کارکتر باشد  ")
                .WithName("نام خانوادگی");


            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(500).WithMessage("{PropertyName} باید حداکثر 250 کارکتر باشد  ")
                .EmailAddress().WithMessage("فرمت ایمیل را بدرستی وارد نمایید.")
                .WithName("ایمیل");


            RuleFor(a => a.UserName)
                .NotEmpty().WithMessage("{PropertyName} را وارد نمایید")
                .NotNull().WithMessage("{PropertyName} را وارد نمایید")
                .MaximumLength(250).WithMessage("{PropertyName} باید حداکثر 250 کارکتر باشد  ")
                .WithName("نام کاربری");
        }
    }
}