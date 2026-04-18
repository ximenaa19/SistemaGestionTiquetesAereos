using GestionAerolineas.src.Modules.FlightRoles.Application.Interfaces;
using GestionAerolineas.src.Modules.FlightRoles.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightRoles.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightRoles.Application.UseCases;

public class CreateFlightRoleUseCase
{
    private readonly IFlightRoleRepository _repository;
    private readonly IFlightRoleValidator _validator;

    public CreateFlightRoleUseCase(
        IFlightRoleRepository repository,
        IFlightRoleValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name)
    {
        var nameVO = FlightRoleName.Create(name);

        await _validator.ValidateNameAsync(nameVO);

        var entity = FlightRole.CreateNew(nameVO);

        await _repository.AddAsync(entity);
    }
}

