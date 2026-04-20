using GestionAerolineas.src.Modules.People.Domain.Aggregate;
using GestionAerolineas.src.Modules.People.Domain.Repositories;
using GestionAerolineas.src.Modules.People.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.People.Application.UseCases;

public class GetPersonByDocumentUseCase
{
    private readonly IPersonRepository _repository;

    public GetPersonByDocumentUseCase(IPersonRepository repository)
    {
        _repository = repository;
    }

    public Task<Person?> ExecuteAsync(int documentTypeId, string documentNumber)
    {
        return _repository.GetByDocumentAsync(
            PersonDocumentTypeId.Create(documentTypeId),
            PersonDocumentNumber.Create(documentNumber)
        );
    }
}

