using GestionAerolineas.src.Modules.People.Domain.Aggregate;
using GestionAerolineas.src.Modules.People.Domain.Repositories;
using GestionAerolineas.src.Modules.People.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.People.Application.UseCases;

public class GetPersonByIdUseCase
{
    private readonly IPersonRepository _repository;

    public GetPersonByIdUseCase(IPersonRepository repository)
    {
        _repository = repository;
    }

    public Task<Person?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(PersonId.Create(id));
    }
}

