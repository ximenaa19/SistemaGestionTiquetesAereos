using GestionAerolineas.src.Modules.People.Domain.Aggregate;
using GestionAerolineas.src.Modules.People.Domain.Repositories;

namespace GestionAerolineas.src.Modules.People.Application.UseCases;

public class GetAllPeopleUseCase
{
    private readonly IPersonRepository _repository;

    public GetAllPeopleUseCase(IPersonRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Person>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

