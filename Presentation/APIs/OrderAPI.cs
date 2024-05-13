using Carter;
using Contract.Abstraction.Shared;
using Contract.DTOs.OrderDTO;
using Contract.Service;
using Contract.Service.Order;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Abstractions;
using static Contract.Service.Order.Command;
using static Contract.Service.Order.Query;

namespace Presentation.APIs
{
    public class OrderAPI : ApiEndpoint, ICarterModule
    {
        private const string BaseUrl = "/api/v{version:apiVersion}/order";
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("order")
                .MapGroup(BaseUrl).HasApiVersion(1);

            group1.MapPost("/", CreateOrder);
            group1.MapGet("/{Order_id}", FindOrderById);
            group1.MapGet("/", GetOrders);
        }

        private async Task<IResult> CreateOrder([FromBody] CreateOrderDTO CreateOrderDTO, ISender sender)
        {
            var command = new CreateOrder(CreateOrderDTO);
            Result<BaseResponse> response = await sender.Send(command);
            if (response.IsFailure) HandleFailure(response);
            return Results.Ok(response);
        }

        private async Task<IResult> FindOrderById(Guid Order_id, ISender _sender)
        {
            var command = new FindOrderById(Order_id);
            Result<Response> repsonse = await _sender.Send(command);
            if (repsonse.IsFailure) HandleFailure(repsonse);
            return Results.Ok(repsonse);
        }

        private async Task<IResult> GetOrders(ISender _sender)
        {
            var command = new GetOrders();
            Result<ICollection<Response>> repsonse = await _sender.Send(command);
            if (repsonse.IsFailure) HandleFailure(repsonse);
            return Results.Ok(repsonse);
        }
    }
}
