using GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.InvoiceItemTypes.Application.Interfaces;

public interface IInvoiceItemTypeValidator
{
    Task ValidateNameAsync(InvoiceItemTypeName name, InvoiceItemTypeId? currentId = null);
}
