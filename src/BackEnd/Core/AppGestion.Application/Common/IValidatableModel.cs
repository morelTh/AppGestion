using FluentValidation;

namespace AppGestion.Application.Common;

public interface IValidatableModel <TApplicationModel> where TApplicationModel:class
{
    IValidator<TApplicationModel> ValidateApplicationModel(ApplicationBaseValidationModelProvider<TApplicationModel> validator);
}