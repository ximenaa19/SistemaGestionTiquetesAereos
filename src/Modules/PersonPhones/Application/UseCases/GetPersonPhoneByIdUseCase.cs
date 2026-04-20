using GestionAerolineas.src.Modules.PersonPhones.Domain.Aggregate;
using GestionAerolineas.src.Modules.PersonPhones.Domain.Repositories;
using GestionAerolineas.src.Modules.PersonPhones.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PersonPhones.Application.UseCases;

public class GetPersonPhoneByIdUseCase
{
    private readonly IPersonPhoneRepository _repository;

    public GetPersonPhoneByIdUseCase(IPersonPhoneRepository repository)
    {
        _repository = repository;
    }

    public Task<PersonPhone?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(PersonPhoneId.Create(id));
    }
}

