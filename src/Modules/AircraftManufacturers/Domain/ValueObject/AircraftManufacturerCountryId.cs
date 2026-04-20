namespace GestionAerolineas.src.Modules.AircraftManufacturers.Domain.ValueObject;

public sealed record AircraftManufacturerCountryId
{
    public int Value { get; }

    private AircraftManufacturerCountryId(int value)
    {
        Value = value;
    }

    public static AircraftManufacturerCountryId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new AircraftManufacturerCountryId(value);
    }
}

