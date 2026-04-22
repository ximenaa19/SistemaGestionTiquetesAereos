namespace GestionAerolineas.src.Modules.Checkins.Domain.ValueObject;

public record CheckinId(int Value)
{
    public static CheckinId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del check-in no es valido");
        return new CheckinId(value);
    }

    public static CheckinId CreateEmpty() => new(0);
}

