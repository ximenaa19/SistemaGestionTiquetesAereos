using GestionAerolineas.src.Modules.DocumentTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.Repositories;

namespace GestionAerolineas.src.Modules.DocumentTypes.Application.UseCases;

public class GetAllDocumentTypesUseCase
{
    private readonly IDocumentTypeRepository _repository;

    public GetAllDocumentTypesUseCase(IDocumentTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DocumentType>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
