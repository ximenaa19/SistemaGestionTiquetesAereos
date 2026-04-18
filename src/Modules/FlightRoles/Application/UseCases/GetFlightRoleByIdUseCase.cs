using GestionAerolineas.src.Modules.FlightRoles.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightRoles.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightRoles.Application.UseCases;

public class GetFlightRoleByIdUseCase
{
    private readonly IFlightRoleRepository _repository;

    public GetFlightRoleByIdUseCase(IFlightRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<FlightRole?> ExecuteAsync(int id)
    {
        var idVO = FlightRoleId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}

