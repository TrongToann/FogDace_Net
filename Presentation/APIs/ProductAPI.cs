using Carter;
using Contract.Abstraction.Shared;
using Contract.DTOs.ProductDTO;
using Contract.Service.Product;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Abstractions;
using static Contract.Service.Product.Command;
using static Contract.Service.Product.Query;

namespace Presentation.APIs
{
    public class ProductAPI : ApiEndpoint, ICarterModule
    {
        private const string BaseUrl = "/api/v{version:apiVersion}/product";
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("product")
                .MapGroup(BaseUrl).HasApiVersion(1);

            group1.MapPost("/", CreateProduct);
            group1.MapGet("/{Product_id}", FindProductById);
            group1.MapGet("/", GetProducts);
        }

        private async Task<IResult> CreateProduct([FromBody] CreateProductDTO CreateProductDTO, ISender sender)
        {
            var command = new CreateProduct(CreateProductDTO);
            Result response = await sender.Send(command);
            if (response.IsFailure) HandleFailure(response);
            return Results.Ok(response);
        }

        private async Task<IResult> FindProductById(Guid Product_id, ISender sender)
        {
            var command = new FindProductById(Product_id);
            Result<Response> response = await sender.Send(command);
            if (response.IsFailure) HandleFailure(response);
            return Results.Ok(response);
        }

        private async Task<IResult> GetProducts(ISender sender)
        {
            var command = new GetProducts();
            Result<ICollection<Response>> response = await sender.Send(command);
            if (response.IsFailure) HandleFailure(response);
            return Results.Ok(response);
        }
    }
}
