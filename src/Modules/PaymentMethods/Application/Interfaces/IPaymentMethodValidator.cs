using GestionAerolineas.src.Modules.PaymentMethods.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentMethods.Application.Interfaces;

public interface IPaymentMethodValidator
{
    Task ValidateCommercialNameAsync(PaymentMethodCommercialName commercialName, PaymentMethodId? currentId = null);
}

