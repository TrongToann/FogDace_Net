using Contract.Abstraction.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Abstractions
{
    public abstract class ApiEndpoint
    {
        protected static IResult HandleFailure(Result result)
        =>
        result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException(),
            IValidationResult validationResult =>
            Results.BadRequest(
                CreateProblemDetails(
                    "Validation Error",
                    StatusCodes.Status400BadRequest,
                    result.Errors[0],
                    validationResult.Errors)),
            _ => Results.BadRequest(
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
