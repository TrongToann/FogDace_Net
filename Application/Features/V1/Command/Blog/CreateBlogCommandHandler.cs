using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Domain.Abstraction.Repositories;
using static Contract.Service.Blog.Command;

namespace Application.Features.V1.Command.Blog
{
    public class CreateBlogCommandHandler : ICommandHandler<CreateBlog>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public CreateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IBlogRepository blogRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blogRepository = blogRepository;
        }

        public async Task<Result> Handle(CreateBlog request, CancellationToken cancellationToken)
        {
            if (await _blogRepository.FindSingleAsync(x => x.Title == request.CreateBlogDTO.Title)
                is not null) return Result.Failure(Error.Validation("Exist Data", "Blog Title Is Already In Use!"));
            var blog = _mapper.Map<Domain.Entities.Blog>(request.CreateBlogDTO);
            blog.Account_id = request.Account_id;
            _blogRepository.Add(blog);
            await _unitOfWork.SaveChangesAsync(request.Account_id);
            foreach(var content in request.CreateBlogDTO.Contents)
            {
                _unitOfWork.GetRepository<Domain.Entities.Content, Guid>()
                    .Add(new Domain.Entities.Content
                    {
                        Blog_id = blog.Id,
                        Title = content.Title,
                        Script = content.Script,
                        Image = content.Image
                    });
            }
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
    }
}
