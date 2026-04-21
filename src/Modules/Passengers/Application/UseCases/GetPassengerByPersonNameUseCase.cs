using GestionAerolineas.src.Modules.Passengers.Domain.Aggregate;
using GestionAerolineas.src.Modules.Passengers.Domain.Repositories;
using GestionAerolineas.src.Modules.Passengers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Passengers.Application.UseCases;

public class GetPassengerByPersonNameUseCase
{
    private readonly IPassengerRepository _repository;

    public GetPassengerByPersonNameUseCase(IPassengerRepository repository)
    {
        _repository = repository;
    }

    public Task<Passenger?> ExecuteAsync(string personName)
    {
        return _repository.GetByPersonNameAsync(PassengerPersonName.Create(personName));
    }
}
