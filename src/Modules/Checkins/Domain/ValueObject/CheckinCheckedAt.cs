namespace GestionAerolineas.src.Modules.Checkins.Domain.ValueObject;

public record CheckinCheckedAt(DateTime Value)
{
    public static CheckinCheckedAt Create(DateTime value)
    {
        if (value == default)
            throw new ArgumentException("fecha_checkin no es valida");
        return new CheckinCheckedAt(value);
    }
}

