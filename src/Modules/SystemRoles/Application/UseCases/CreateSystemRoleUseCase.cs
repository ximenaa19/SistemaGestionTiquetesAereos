using GestionAerolineas.src.Modules.SystemRoles.Application.Interfaces;
using GestionAerolineas.src.Modules.SystemRoles.Domain.Aggregate;
using GestionAerolineas.src.Modules.SystemRoles.Domain.Repositories;
using GestionAerolineas.src.Modules.SystemRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.SystemRoles.Application.UseCases;

public class CreateSystemRoleUseCase
{
    private readonly ISystemRoleRepository _repository;
    private readonly ISystemRoleValidator _validator;

    public CreateSystemRoleUseCase(
        ISystemRoleRepository repository,
        ISystemRoleValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name, string? description)
    {
        var nameVO = SystemRoleName.Create(name);
        var descriptionVO = SystemRoleDescription.Create(description);

        await _validator.ValidateNameAsync(nameVO);

        var entity = SystemRole.CreateNew(nameVO, descriptionVO);

        await _repository.AddAsync(entity);
    }
}
