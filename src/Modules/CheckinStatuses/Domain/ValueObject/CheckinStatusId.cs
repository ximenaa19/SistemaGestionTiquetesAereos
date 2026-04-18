namespace GestionAerolineas.src.Modules.CheckinStatuses.Domain.ValueObject;

public sealed record CheckinStatusId
{
    public int Value { get; }

    private CheckinStatusId(int value)
    {
        Value = value;
    }

    public static CheckinStatusId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new CheckinStatusId(value);
    }

    public static CheckinStatusId CreateEmpty()
    {
        return new CheckinStatusId(0);
    }
}
