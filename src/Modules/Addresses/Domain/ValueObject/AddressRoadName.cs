namespace GestionAerolineas.src.Modules.Addresses.Domain.ValueObject;

public sealed record AddressRoadName
{
    public string Value { get; }

    private AddressRoadName(string value)
    {
        Value = value;
    }

    public static AddressRoadName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre de la vía no puede ser nulo ni vacío");

        value = value.Trim();

        if (value.Length > 100)
            throw new ArgumentException("El nombre de la vía no puede tener más de 100 caracteres");

        return new AddressRoadName(value);
    }
}

