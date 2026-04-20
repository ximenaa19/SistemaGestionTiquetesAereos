using GestionAerolineas.src.Modules.PersonEmails.Domain.Aggregate;
using GestionAerolineas.src.Modules.PersonEmails.Domain.Repositories;
using GestionAerolineas.src.Modules.PersonEmails.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PersonEmails.Application.UseCases;

public class GetPersonEmailByIdUseCase
{
    private readonly IPersonEmailRepository _repository;

    public GetPersonEmailByIdUseCase(IPersonEmailRepository repository)
    {
        _repository = repository;
    }

    public Task<PersonEmail?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(PersonEmailId.Create(id));
    }
}

