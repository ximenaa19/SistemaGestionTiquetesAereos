namespace GestionAerolineas.src.Modules.AircraftManufacturers.Domain.ValueObject;

public sealed record AircraftManufacturerId
{
    public int Value { get; }

    private AircraftManufacturerId(int value)
    {
        Value = value;
    }

    public static AircraftManufacturerId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new AircraftManufacturerId(value);
    }

    public static AircraftManufacturerId CreateEmpty()
    {
        return new AircraftManufacturerId(0);
    }
}

