using GestionAerolineas.src.Modules.PersonPhones.Domain.Aggregate;
using GestionAerolineas.src.Modules.PersonPhones.Domain.Repositories;

namespace GestionAerolineas.src.Modules.PersonPhones.Application.UseCases;

public class GetAllPersonPhonesUseCase
{
    private readonly IPersonPhoneRepository _repository;

    public GetAllPersonPhonesUseCase(IPersonPhoneRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<PersonPhone>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

