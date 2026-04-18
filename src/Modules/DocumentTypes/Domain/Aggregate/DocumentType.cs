using GestionAerolineas.src.Modules.DocumentTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.DocumentTypes.Domain.Aggregate;

public class DocumentType
{
    public DocumentTypeId Id { get; private set; }
    public DocumentTypeName Name { get; private set; }
    public DocumentTypeCode Code { get; private set; }

    private DocumentType(
        DocumentTypeId id,
        DocumentTypeName name,
        DocumentTypeCode code)
    {
        Id = id;
        Name = name;
        Code = code;
    }

    public static DocumentType Create(
        DocumentTypeId id,
        DocumentTypeName name,
        DocumentTypeCode code)
    {
        return new DocumentType(id, name, code);
    }

    public static DocumentType Create(
        DocumentTypeName name,
        DocumentTypeCode code)
    {
        return new DocumentType(DocumentTypeId.CreateNew(), name, code);
    }

    public void UpdateName(DocumentTypeName name)
    {
        Name = name;
    }

    public void UpdateCode(DocumentTypeCode code)
    {
        Code = code;
    }
}
