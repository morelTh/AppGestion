using AppGestion.Application.Models.Common;
using Microsoft.AspNetCore.Http;

namespace AppGestion.WebFramework.WebExtensions;

public static class EndpointExtensions
{
    public static IResult ToEndpointResult<TModel>(this OperationResult<TModel> result)
    {
        ArgumentNullException.ThrowIfNull(result, nameof(OperationResult<TModel>));

        if (result.IsSuccess) return result.Result is bool ?  Results.Ok() :Results.Ok(result.Result);

        if (result.IsNotFound) return string.IsNullOrEmpty(result.ErrorMessage) ? Results.NotFound() : Results.NotFound(new Dictionary<string, List<string>>()
        {
            {"GeneralError",new (){result.ErrorMessage}}
        });

        return string.IsNullOrEmpty(result.ErrorMessage) ? Results.BadRequest() : Results.BadRequest(new Dictionary<string,List<string>>()
        {
            {"GeneralError",new (){result.ErrorMessage}}
        });
    }
    
}