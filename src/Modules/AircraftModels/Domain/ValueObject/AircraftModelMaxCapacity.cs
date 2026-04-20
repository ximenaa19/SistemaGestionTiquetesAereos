namespace GestionAerolineas.src.Modules.AircraftModels.Domain.ValueObject;

public sealed record AircraftModelMaxCapacity
{
    public int Value { get; }

    private AircraftModelMaxCapacity(int value)
    {
        Value = value;
    }

    public static AircraftModelMaxCapacity Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("La capacidad máxima debe ser mayor a 0");

        return new AircraftModelMaxCapacity(value);
    }
}

