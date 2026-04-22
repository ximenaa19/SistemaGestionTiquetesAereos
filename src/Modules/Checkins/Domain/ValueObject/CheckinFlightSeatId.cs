namespace GestionAerolineas.src.Modules.Checkins.Domain.ValueObject;

public record CheckinFlightSeatId(int Value)
{
    public static CheckinFlightSeatId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("asiento_vuelo_id no es valido");
        return new CheckinFlightSeatId(value);
    }
}

