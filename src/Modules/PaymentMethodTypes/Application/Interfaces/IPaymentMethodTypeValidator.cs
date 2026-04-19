using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentMethodTypes.Application.Interfaces;

public interface IPaymentMethodTypeValidator
{
    Task ValidateNameAsync(PaymentMethodTypeName name);
}
