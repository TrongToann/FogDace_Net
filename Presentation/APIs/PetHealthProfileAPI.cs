using Carter;
using Contract.Abstraction.Shared;
using Contract.DTOs.PetHealthProfileDTO;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Abstractions;
using static Contract.Service.PetHealthProfile.Command;

namespace Presentation.APIs
{
    public class PetHealthProfileAPI : ApiEndpoint, ICarterModule
    {
        private const string BaseUrl = "/api/v{version:apiVersion}/petHealth";
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("petHealth")
                .MapGroup(BaseUrl).HasApiVersion(1);

            group1.MapPost("/", CreatePetHealthProfile);
        }

        private async Task<IResult> CreatePetHealthProfile([FromBody] CreatePetHealthProfileDTO CreatePetHealthProfileDTO, ISender sender)
        {
            Guid account_id = Guid.Parse("C1FE99C1-3150-4951-45AF-08DC4953B2FE");
            var command = new CreatePetHealthProfile(CreatePetHealthProfileDTO, account_id);
            Result response = await sender.Send(command);
            if(response.IsFailure) HandleFailure(response);
            return Results.Ok(response);
        }
    }
}
