namespace GestionAerolineas.src.Modules.Addresses.Domain.ValueObject;

public sealed record AddressCityId
{
    public int Value { get; }

    private AddressCityId(int value)
    {
        Value = value;
    }

    public static AddressCityId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new AddressCityId(value);
    }
}

