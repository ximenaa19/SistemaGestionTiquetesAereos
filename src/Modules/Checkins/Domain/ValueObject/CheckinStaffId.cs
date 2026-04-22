namespace GestionAerolineas.src.Modules.Checkins.Domain.ValueObject;

public record CheckinStaffId(int Value)
{
    public static CheckinStaffId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("personal_id no es valido");
        return new CheckinStaffId(value);
    }
}

