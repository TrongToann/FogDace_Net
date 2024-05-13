using Contract.Abstraction.Message;
using Contract.DTOs.BlogDTO;

namespace Contract.Service.Blog
{
    public static class Command
    {
        public record CreateBlog(CreateBlogDTO CreateBlogDTO, Guid Account_id) : ICommand { }
    }
}
