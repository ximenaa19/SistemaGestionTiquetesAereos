using GestionAerolineas.src.Modules.PaymentStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentStates.Domain.Aggregate;

public class PaymentState
{
    public PaymentStateId Id { get; private set; }
    public PaymentStateName Name { get; private set; }

    private PaymentState(PaymentStateId id, PaymentStateName name)
    {
        Id = id;
        Name = name;
    }

    public static PaymentState Create(PaymentStateId id, PaymentStateName name)
    {
        return new PaymentState(id, name);
    }

    public static PaymentState CreateNew(PaymentStateName name)
    {
        return new PaymentState(PaymentStateId.CreateEmpty(), name);
    }
}
