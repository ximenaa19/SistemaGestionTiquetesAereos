namespace GestionAerolineas.src.Modules.Addresses.Domain.ValueObject;

public sealed record AddressRoadTypeId
{
    public int Value { get; }

    private AddressRoadTypeId(int value)
    {
        Value = value;
    }

    public static AddressRoadTypeId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new AddressRoadTypeId(value);
    }
}

