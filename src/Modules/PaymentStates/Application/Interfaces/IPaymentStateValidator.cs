using GestionAerolineas.src.Modules.PaymentStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentStates.Application.Interfaces;

public interface IPaymentStateValidator
{
    Task ValidateNameAsync(PaymentStateName name, PaymentStateId? currentId = null);
}
