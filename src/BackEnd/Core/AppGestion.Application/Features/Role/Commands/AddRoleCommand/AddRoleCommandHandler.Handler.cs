using AppGestion.Application.Contracts.Identity;
using AppGestion.Application.Models.Common;
using Mediator;

namespace AppGestion.Application.Features.Role.Commands.AddRoleCommand;

internal class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, OperationResult<bool>>
{
    private readonly IAppRoleManagerService _roleManagerService;

    public AddRoleCommandHandler(IAppRoleManagerService roleManagerService)
    {
        _roleManagerService = roleManagerService;
    }

    public async ValueTask<OperationResult<bool>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var addRoleResul =
            await _roleManagerService.CreateRoleAsync(new Domain.Entities.Role() { Name = request.RoleName });

        if (addRoleResul.Succeeded)
            return OperationResult<bool>.SuccessResult(true);

        var errors = string.Join("\n", addRoleResul.Errors.Select(e => e.Description));

        return OperationResult<bool>.FailureResult(errors);
    }
}