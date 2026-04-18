using GestionAerolineas.src.Modules.Permissions.Application.Interfaces;
using GestionAerolineas.src.Modules.Permissions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Permissions.Domain.Repositories;
using GestionAerolineas.src.Modules.Permissions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Permissions.Application.UseCases;

public class CreatePermissionUseCase
{
    private readonly IPermissionRepository _repository;
    private readonly IPermissionValidator _validator;

    public CreatePermissionUseCase(
        IPermissionRepository repository,
        IPermissionValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name, string? description)
    {
        var nameVO = PermissionName.Create(name);
        var descriptionVO = PermissionDescription.Create(description);

        await _validator.ValidateNameAsync(nameVO);

        var entity = Permission.CreateNew(nameVO, descriptionVO);

        await _repository.AddAsync(entity);
    }
}
