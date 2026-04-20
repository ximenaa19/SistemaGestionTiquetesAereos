namespace GestionAerolineas.src.Modules.Addresses.Domain.ValueObject;

public sealed record AddressId
{
    public int Value { get; }

    private AddressId(int value)
    {
        Value = value;
    }

    public static AddressId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new AddressId(value);
    }

    public static AddressId CreateEmpty()
    {
        return new AddressId(0);
    }
}

