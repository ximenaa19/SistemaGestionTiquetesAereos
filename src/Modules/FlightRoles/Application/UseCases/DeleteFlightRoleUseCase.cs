using GestionAerolineas.src.Modules.FlightRoles.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightRoles.Application.UseCases;

public class DeleteFlightRoleUseCase
{
    private readonly IFlightRoleRepository _repository;

    public DeleteFlightRoleUseCase(IFlightRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var flightRoleId = FlightRoleId.Create(id);
        var flightRole = await _repository.GetByIdAsync(flightRoleId);

        if (flightRole is null)
        {
            throw new KeyNotFoundException($"FlightRole con id '{flightRoleId.Value}' no existe.");
        }

        await _repository.DeleteAsync(flightRole);
    }
}

