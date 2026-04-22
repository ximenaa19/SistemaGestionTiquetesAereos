using GestionAerolineas.src.Modules.Invoices.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Invoices.Application.Interfaces;

public interface IInvoiceValidator
{
    Task ValidateReservationExistsAsync(InvoiceReservationId reservationId);
    Task ValidateReservationAllowsInvoiceAsync(InvoiceReservationId reservationId);
    Task ValidateReservationIsUniqueAsync(InvoiceReservationId reservationId, InvoiceId? excludingInvoiceId = null);
    Task ValidateInvoiceNumberUniqueAsync(InvoiceNumber number, InvoiceId? excludingInvoiceId = null);
    Task ValidateDeletableAsync(InvoiceId invoiceId);
}

