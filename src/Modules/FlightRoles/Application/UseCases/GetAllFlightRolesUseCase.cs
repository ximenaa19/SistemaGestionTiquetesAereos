using GestionAerolineas.src.Modules.FlightRoles.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightRoles.Domain.Repositories;

namespace GestionAerolineas.src.Modules.FlightRoles.Application.UseCases;

public class GetAllFlightRolesUseCase
{
    private readonly IFlightRoleRepository _repository;

    public GetAllFlightRolesUseCase(IFlightRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<FlightRole>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}

