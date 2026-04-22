using GestionAerolineas.src.Modules.InvoiceItems.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.InvoiceItems.Application.Interfaces;

public interface IInvoiceItemValidator
{
    Task ValidateInvoiceExistsAsync(InvoiceItemInvoiceId invoiceId);
    Task ValidateItemTypeExistsAsync(InvoiceItemTypeId itemTypeId);
    Task ValidateReservationPassengerAsync(InvoiceItemInvoiceId invoiceId, InvoiceItemReservationPassengerId reservationPassengerId);
}

