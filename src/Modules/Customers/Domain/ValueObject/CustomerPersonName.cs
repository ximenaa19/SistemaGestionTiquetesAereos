namespace GestionAerolineas.src.Modules.Customers.Domain.ValueObject;

public sealed record CustomerPersonName
{
    public string Value { get; }

    private CustomerPersonName(string value)
    {
        Value = value;
    }

    public static CustomerPersonName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre de la persona no puede estar vacio");

        return new CustomerPersonName(value.Trim());
    }

    public static string Normalize(string value)
    {
        return (value ?? string.Empty).Trim().ToUpperInvariant();
    }
}
