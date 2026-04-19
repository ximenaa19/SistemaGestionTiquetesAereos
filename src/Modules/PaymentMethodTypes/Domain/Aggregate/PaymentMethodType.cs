using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.Aggregate;

public class PaymentMethodType
{
    public PaymentMethodTypeId Id { get; private set; }
    public PaymentMethodTypeName Name { get; private set; }

    private PaymentMethodType(PaymentMethodTypeId id, PaymentMethodTypeName name)
    {
        Id = id;
        Name = name;
    }

    public static PaymentMethodType Create(PaymentMethodTypeId id, PaymentMethodTypeName name)
    {
        return new PaymentMethodType(id, name);
    }

    public static PaymentMethodType CreateNew(PaymentMethodTypeName name)
    {
        return new PaymentMethodType(PaymentMethodTypeId.CreateEmpty(), name);
    }
}
