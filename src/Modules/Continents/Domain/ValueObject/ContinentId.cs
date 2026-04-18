namespace GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

public sealed record ContinentId
{
    public int Value { get; }

    private ContinentId(int value)
    {
        Value = value;
    }

    public static ContinentId Create(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("El valor no puede ser menor a 1");
        }

        return new ContinentId(value);
    }
}

