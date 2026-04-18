using GestionAerolineas.src.Modules.DocumentTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.DocumentTypes.Application.Services;

public class DocumentTypeValidator : IDocumentTypeValidator
{
    private readonly IDocumentTypeRepository _repository;

    public DocumentTypeValidator(IDocumentTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateAsync(
        DocumentTypeName name,
        DocumentTypeCode code,
        DocumentTypeId? currentId = null)
    {
        var existingByName = await _repository.GetByNameAsync(name);

        if (existingByName is not null && existingByName.Id != currentId)
        {
            throw new Exception("Ya existe un DocumentType con ese nombre");
        }

        var existingByCode = await _repository.GetByCodeAsync(code);

        if (existingByCode is not null && existingByCode.Id != currentId)
        {
            throw new Exception("Ya existe un DocumentType con ese codigo");
        }
    }
}
