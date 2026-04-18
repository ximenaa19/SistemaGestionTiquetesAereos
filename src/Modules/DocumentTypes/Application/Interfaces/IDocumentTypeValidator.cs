using GestionAerolineas.src.Modules.DocumentTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.DocumentTypes.Application.Interfaces;

public interface IDocumentTypeValidator
{
    Task ValidateAsync(
        DocumentTypeName name,
        DocumentTypeCode code,
        DocumentTypeId? currentId = null);
}
