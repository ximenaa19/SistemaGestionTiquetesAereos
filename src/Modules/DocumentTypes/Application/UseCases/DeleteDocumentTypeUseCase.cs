using GestionAerolineas.src.Modules.DocumentTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.DocumentTypes.Application.UseCases;

public class DeleteDocumentTypeUseCase
{
    private readonly IDocumentTypeRepository _repository;

    public DeleteDocumentTypeUseCase(IDocumentTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var documentTypeId = DocumentTypeId.Create(id);
        var documentType = await _repository.GetByIdAsync(documentTypeId);

        if (documentType is null)
        {
            throw new KeyNotFoundException($"DocumentType con id '{documentTypeId.Value}' no existe.");
        }

        await _repository.DeleteAsync(documentType);
    }
}
