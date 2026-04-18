using GestionAerolineas.src.Modules.DocumentTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.DocumentTypes.Application.UseCases;

public class GetDocumentTypeByIdUseCase
{
    private readonly IDocumentTypeRepository _repository;

    public GetDocumentTypeByIdUseCase(IDocumentTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<DocumentType?> ExecuteAsync(int id)
    {
        return await _repository.GetByIdAsync(DocumentTypeId.Create(id));
    }
}
