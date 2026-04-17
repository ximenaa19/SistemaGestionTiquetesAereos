using GestionAerolineas.src.Modules.DocumentTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.DocumentTypes.Domain.Repositories;

public interface IDocumentTypeRepository
{
    Task<IEnumerable<DocumentType>> GetAllAsync();
    Task<DocumentType?> GetByIdAsync(DocumentTypeId id);
    Task<DocumentType?> GetByCodeAsync(DocumentTypeCode code);

    Task AddAsync(DocumentType entity);
    Task UpdateAsync(DocumentType entity);
    Task DeleteAsync(DocumentTypeId id);

    Task<bool> ExistsAsync(DocumentTypeId id);
}