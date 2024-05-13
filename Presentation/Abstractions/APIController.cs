using Contract.Abstraction.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Abstractions
{
    public class APIController : ControllerBase
    {
        protected readonly ISender Sender;
        protected APIController(ISender sender) =>
            Sender = sender;
        protected IActionResult HandleFailure(Result result)
        =>
            result switch
            {
                { IsSuccess: true } => throw new InvalidOperationException(),
                IValidationResult validationResult =>
                BadRequest(
                    CreateProblemDetails(
                        "Validation Error",
                        StatusCodes.Status400BadRequest,
                        result.Errors[0],
                        validationResult.Errors)),
                _ => BadRequest(
                    CreateProblemDetails(
                        "Bad Request",
                        StatusCodes.Status400BadRequest,
                        result.Errors[0])),
            };
        private static ProblemDetails CreateProblemDetails(
                string title,
                int status,
                Error error,
                Error[] errors = null
            ) => new()
            {
                Title = title,
                Type = error.Code,
                Detail = error.Description,
                Status = status,
                Extensions = { { nameof(errors), errors } }
            };


    }
}
