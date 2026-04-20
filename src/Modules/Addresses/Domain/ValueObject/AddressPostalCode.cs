namespace GestionAerolineas.src.Modules.Addresses.Domain.ValueObject;

public sealed record AddressPostalCode
{
    public string? Value { get; }

    private AddressPostalCode(string? value)
    {
        Value = value;
    }

    public static AddressPostalCode Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new AddressPostalCode((string?)null);

        value = value.Trim();

        if (value.Length > 20)
            throw new ArgumentException("El código postal no puede tener más de 20 caracteres");

        return new AddressPostalCode(value);
    }
}

