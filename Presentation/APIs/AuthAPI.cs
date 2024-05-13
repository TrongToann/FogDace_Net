using Application.Abstractions;
using Carter;
using Contract.Abstraction.Shared;
using Contract.DTOs.Auth;
using Contract.Service;
using Contract.Service.Auth;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Abstractions;
using static Contract.Service.Auth.Command;

namespace BirdFood.Presentation.APIs
{
    public class AuthAPI : ApiEndpoint, ICarterModule
    {
        private const string BaseUrl = "/api/v{version:apiVersion}/auth";
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("auth")
                .MapGroup(BaseUrl).HasApiVersion(1);

            group1.MapPost("/register", Register);
            group1.MapPost("/login", Login);
            group1.MapPost("/logout", Logout);
        }
        private async Task<IResult> Register([FromBody] RegisterDTO RegisterDTO, ISender sender)
        {
            var command = new Register(RegisterDTO);
            Result<BaseResponse> response = await sender.Send(command);
            if (response.IsFailure) HandleFailure(response);
            return Results.Ok(response);
        }
        private async Task<IResult> Login([FromBody] LoginDTO LoginDTO, ISender sender)
        {
            var command = new Login(LoginDTO);
            Result<Response> response = await sender.Send(command);
            if (response.IsFailure) HandleFailure(response);
            return Results.Ok(response);
        }
        private async Task<IResult> Logout(IJwtTokenService _tokenService, ISender sender, HttpRequest request)
        {
            Guid account_Id = _tokenService.GetClaimsAccountIdFromToken(request);
            var command = new Logout(account_Id);
            Result<BaseResponse> response = await sender.Send(command);
            if (response.IsFailure) HandleFailure(response);
            return Results.Ok(response);
        }
    }
}
