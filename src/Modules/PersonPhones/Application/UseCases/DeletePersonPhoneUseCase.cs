using GestionAerolineas.src.Modules.PersonPhones.Domain.Repositories;
using GestionAerolineas.src.Modules.PersonPhones.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PersonPhones.Application.UseCases;

public class DeletePersonPhoneUseCase
{
    private readonly IPersonPhoneRepository _repository;

    public DeletePersonPhoneUseCase(IPersonPhoneRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(PersonPhoneId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}

