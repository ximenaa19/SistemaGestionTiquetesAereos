using GestionAerolineas.src.Modules.Payments.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Payments.Application.Interfaces;

public interface IPaymentValidator
{
    Task ValidateReservationExistsAsync(PaymentReservationId reservationId);
    Task ValidateReservationAllowsPaymentsAsync(PaymentReservationId reservationId);
    Task ValidatePaymentStateExistsAsync(PaymentStateId stateId);
    Task ValidatePaymentMethodExistsAsync(PaymentMethodId methodId);
    Task ValidateNotOverpayAsync(PaymentReservationId reservationId, PaymentAmount amount, PaymentStateId stateId, PaymentId? excludingId = null);
    Task ValidateDeletableAsync(PaymentId paymentId);
}

