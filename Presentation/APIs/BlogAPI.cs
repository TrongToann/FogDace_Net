using Carter;
using Contract.Abstraction.Shared;
using Contract.DTOs.BlogDTO;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Abstractions;
using static Contract.Service.Blog.Command;

namespace Presentation.APIs
{
    public class BlogAPI : ApiEndpoint, ICarterModule
    {
        private const string BaseUrl = "/api/v{version:apiVersion}/blog";
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("blog")
                .MapGroup(BaseUrl).HasApiVersion(1);

            group1.MapPost("/", CreateBlog);
        }

        private async Task<IResult> CreateBlog([FromBody] CreateBlogDTO CreateBlogDTO, ISender sender)
        {
            Guid account_id = Guid.Parse("C1FE99C1-3150-4951-45AF-08DC4953B2FE");
            var command = new CreateBlog(CreateBlogDTO, account_id);
            Result response = await sender.Send(command);
            if (response.IsFailure) HandleFailure(response);
            return Results.Ok(response);
        }
    }
}
