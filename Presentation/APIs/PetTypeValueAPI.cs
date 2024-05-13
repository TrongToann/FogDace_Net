using Carter;
using Contract.Abstraction.Shared;
using Contract.DTOs.PetTypeDTO;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Abstractions;
using static Contract.Service.PetType.Command;

namespace Presentation.APIs
{
    public class PetTypeValueAPI : ApiEndpoint, ICarterModule
    {
        private const string BaseUrl = "/api/v{version:apiVersion}/petType";
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("petType")
                .MapGroup(BaseUrl).HasApiVersion(1);

            group1.MapPost("/", CreatePetType);
        }

        private async Task<IResult> CreatePetType([FromBody] CreatePetTypeDTO CreatePetTypeDTO, ISender sender)
        {
            var command = new CreatePetType(CreatePetTypeDTO);
            Result response = await sender.Send(command);
            if (response.IsFailure) HandleFailure(response);
            return Results.Ok(response);
        }
    }
}
