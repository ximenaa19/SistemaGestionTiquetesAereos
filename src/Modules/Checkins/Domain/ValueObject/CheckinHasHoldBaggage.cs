namespace GestionAerolineas.src.Modules.Checkins.Domain.ValueObject;

public record CheckinHasHoldBaggage(bool Value)
{
    public static CheckinHasHoldBaggage Create(bool value) => new(value);
}

