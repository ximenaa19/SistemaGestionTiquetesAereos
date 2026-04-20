using GestionAerolineas.src.Modules.PersonEmails.Domain.Repositories;
using GestionAerolineas.src.Modules.PersonEmails.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PersonEmails.Application.UseCases;

public class DeletePersonEmailUseCase
{
    private readonly IPersonEmailRepository _repository;

    public DeletePersonEmailUseCase(IPersonEmailRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(PersonEmailId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}

