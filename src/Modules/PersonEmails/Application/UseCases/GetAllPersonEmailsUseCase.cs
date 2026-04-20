using GestionAerolineas.src.Modules.PersonEmails.Domain.Aggregate;
using GestionAerolineas.src.Modules.PersonEmails.Domain.Repositories;

namespace GestionAerolineas.src.Modules.PersonEmails.Application.UseCases;

public class GetAllPersonEmailsUseCase
{
    private readonly IPersonEmailRepository _repository;

    public GetAllPersonEmailsUseCase(IPersonEmailRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<PersonEmail>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

