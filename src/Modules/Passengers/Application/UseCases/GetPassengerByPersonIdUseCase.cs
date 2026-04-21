using GestionAerolineas.src.Modules.Passengers.Domain.Aggregate;
using GestionAerolineas.src.Modules.Passengers.Domain.Repositories;
using GestionAerolineas.src.Modules.Passengers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Passengers.Application.UseCases;

public class GetPassengerByPersonIdUseCase
{
    private readonly IPassengerRepository _repository;

    public GetPassengerByPersonIdUseCase(IPassengerRepository repository)
    {
        _repository = repository;
    }

    public Task<Passenger?> ExecuteAsync(int personId)
    {
        return _repository.GetByPersonIdAsync(PassengerPersonId.Create(personId));
    }
}
