namespace GestionAerolineas.src.Modules.Checkins.Domain.ValueObject;

public record CheckinStatusId(int Value)
{
    public static CheckinStatusId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("estado_checkin_id no es valido");
        return new CheckinStatusId(value);
    }
}

