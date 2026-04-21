using GestionAerolineas.src.Modules.Passengers.Domain.Aggregate;
using GestionAerolineas.src.Modules.Passengers.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Passengers.Application.UseCases;

public class GetAllPassengersUseCase
{
    private readonly IPassengerRepository _repository;

    public GetAllPassengersUseCase(IPassengerRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Passenger>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}
