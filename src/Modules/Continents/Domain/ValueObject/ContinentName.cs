namespace GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

public sealed record ContinentName
{
    public string Value { get; }


    private ContinentName(string value)
    {
        Value = value;
    }

    public static ContinentName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("El nombre del continente no puede estar vacío.");
        }

        if (value.Length > 50)
        {
            throw new ArgumentException(
                "El nombre del continente no puede tener más de 50 caracteres."
            );
        }

        return new ContinentName(value.Trim());
    }

    public override string ToString() => Value;
}


