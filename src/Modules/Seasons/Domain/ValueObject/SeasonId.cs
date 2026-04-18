namespace GestionAerolineas.src.Modules.Seasons.Domain.ValueObject;

public sealed record SeasonId
{
    public int Value { get; }

    private SeasonId(int value)
    {
        Value = value;
    }

    public static SeasonId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new SeasonId(value);
    }

    public static SeasonId CreateEmpty()
    {
        return new SeasonId(0);
    }
}
