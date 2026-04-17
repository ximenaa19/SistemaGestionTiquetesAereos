namespace GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

public sealed record ContinentsId
{
    public int Value { get; }

    private ContinentsId(int value)
    {
        Value = value;
    }

    public static ContinentsId Create(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("El valor no puede ser menor a 1");
        }

        return new ContinentsId(value);
    }

    public static ContinentsId CreateEmpty() => new ContinentsId(0);
}


