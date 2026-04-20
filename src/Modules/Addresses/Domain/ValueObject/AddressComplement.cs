namespace GestionAerolineas.src.Modules.Addresses.Domain.ValueObject;

public sealed record AddressComplement
{
    public string? Value { get; }

    private AddressComplement(string? value)
    {
        Value = value;
    }

    public static AddressComplement Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new AddressComplement((string?)null);

        value = value.Trim();

        if (value.Length > 100)
            throw new ArgumentException("El complemento no puede tener más de 100 caracteres");

        return new AddressComplement(value);
    }
}
