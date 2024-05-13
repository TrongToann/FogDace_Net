using Carter;
using Contract.Abstraction.Shared;
using Contract.DTOs.PetDTO;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Abstractions;
using static Contract.Service.Pet.Command;

namespace Presentation.APIs
{
    public class PetAPI : ApiEndpoint, ICarterModule
    {
        private const string BaseUrl = "/api/v{version:apiVersion}/pet";
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("pet")
                .MapGroup(BaseUrl).HasApiVersion(1);

            group1.MapPost("/", async ([FromBody] CreatePetDTO CreatePetDTO, ISender sender) =>
            {
                var command = new CreatePet(CreatePetDTO);
                Result response = await sender.Send(command);
                if (response.IsFailure) HandleFailure(response);
                return Results.Ok(response);
            });
        }
    }
}
