using FluentValidation;
using static Contract.Service.Blog.Command;

namespace Contract.Service.Blog.Validators
{
    public class CreateBlogValidator : AbstractValidator<CreateBlog>
    {
        public CreateBlogValidator()
        {
            RuleFor(x => x.CreateBlogDTO.Contents).NotEmpty();
            RuleFor(x => x.CreateBlogDTO.Title).NotEmpty();
            RuleFor(x => x.CreateBlogDTO.Image).NotEmpty();
            RuleFor(x => x.CreateBlogDTO.Description).NotEmpty();
            RuleFor(x => x.CreateBlogDTO.Contents)
                .Must(content => content.All(op => !string.IsNullOrEmpty(op.Title)))
                .Must(content => content.All(op => !string.IsNullOrEmpty(op.Image)))
                .Must(content => content.All(op => !string.IsNullOrEmpty(op.Script)))
                .WithMessage("Invalid Content Blog!");
        }
    }
}
