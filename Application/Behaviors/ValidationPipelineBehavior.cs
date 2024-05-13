﻿using Contract.Abstraction.Shared;
using FluentValidation;
using MediatR;

namespace Application.Behaviors
{
    public class ValidationPipelineBehavior<TRequest, TRespone>
        : IPipelineBehavior<TRequest, TRespone>
        where TRequest : IRequest<TRespone>
        where TRespone : Result
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TRespone> Handle(TRequest request, RequestHandlerDelegate<TRespone> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }
            Error[] errors = _validators
                .Select(validator => validator.Validate(request))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure is not null)
                .Select(failure => new Error(
                    failure.PropertyName,
                    failure.ErrorMessage
                    ))
                .Distinct()
                .ToArray();
            if (errors.Any())
            {
                return CreateValidationResult<TRespone>(errors);
            }
            return await next();
        }
        public static TResult CreateValidationResult<TResult>(Error[] errors)
            where TResult : Result
        {
            if (typeof(TResult) == typeof(Result))
            {
                return (ValidationResult.WithErrors(errors) as TResult)!;
            }
            object validationResult = typeof(ValidationResult<>)
                .GetGenericTypeDefinition()
                .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
                .GetMethod(nameof(ValidationResult.WithErrors))!
                .Invoke(null, new object[] { errors })!;
            return (TResult)validationResult;
        }
    }
}
