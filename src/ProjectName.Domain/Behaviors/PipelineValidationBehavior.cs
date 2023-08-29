using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ValidationException = FluentValidation.ValidationException;

namespace ProjectName.Domain.Behavior
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<ValidationPipelineBehavior<TRequest, TResponse>> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ValidationPipelineBehavior(ILogger<ValidationPipelineBehavior<TRequest, TResponse>> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            IValidator<TRequest>? _validator = null!;

            try
            {
                _validator = (IValidator<TRequest>?)_serviceProvider.GetService(typeof(IValidator<TRequest>));
            }
            catch (Exception ex) 
            {
                _logger.LogTrace(ex, "Validation failed for object");
            }

            if (_validator is not null)
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }
            }

            return await next();
        }
    }
}
