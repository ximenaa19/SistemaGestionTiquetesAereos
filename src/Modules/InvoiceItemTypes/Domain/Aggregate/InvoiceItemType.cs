using GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.Aggregate;

public class InvoiceItemType
{
    public InvoiceItemTypeId Id { get; private set; }
    public InvoiceItemTypeName Name { get; private set; }

    private InvoiceItemType(InvoiceItemTypeId id, InvoiceItemTypeName name)
    {
        Id = id;
        Name = name;
    }

    public static InvoiceItemType Create(InvoiceItemTypeId id, InvoiceItemTypeName name)
    {
        return new InvoiceItemType(id, name);
    }

    public static InvoiceItemType CreateNew(InvoiceItemTypeName name)
    {
        return new InvoiceItemType(InvoiceItemTypeId.CreateEmpty(), name);
    }
}
