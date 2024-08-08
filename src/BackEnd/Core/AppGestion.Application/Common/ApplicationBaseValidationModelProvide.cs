using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AppGestion.Application.Common;

public class ApplicationBaseValidationModelProvider<TApplicationModel>:AbstractValidator<TApplicationModel>
{
    public IServiceScope ServiceProvider { get; }
    public ApplicationBaseValidationModelProvider(IServiceScope serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }
}