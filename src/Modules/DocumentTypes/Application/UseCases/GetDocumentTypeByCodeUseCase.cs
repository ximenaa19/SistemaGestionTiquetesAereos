using GestionAerolineas.src.Modules.DocumentTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.DocumentTypes.Application.UseCases;

public class GetDocumentTypeByCodeUseCase
{
    private readonly IDocumentTypeRepository _repository;

    public GetDocumentTypeByCodeUseCase(IDocumentTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<DocumentType?> ExecuteAsync(string code)
    {
        return await _repository.GetByCodeAsync(DocumentTypeCode.Create(code));
    }
}
