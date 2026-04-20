using GestionAerolineas.src.Modules.Aircraft.Domain.Aggregate;
using GestionAerolineas.src.Modules.Aircraft.Domain.Repositories;
using GestionAerolineas.src.Modules.Aircraft.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Aircraft.Application.UseCases;

public class GetAircraftByRegistrationUseCase
{
    private readonly IAircraftRepository _repository;

    public GetAircraftByRegistrationUseCase(IAircraftRepository repository)
    {
        _repository = repository;
    }

    public Task<AircraftAggregate?> ExecuteAsync(string registration)
    {
        return _repository.GetByRegistrationAsync(AircraftRegistration.Create(registration));
    }
}

