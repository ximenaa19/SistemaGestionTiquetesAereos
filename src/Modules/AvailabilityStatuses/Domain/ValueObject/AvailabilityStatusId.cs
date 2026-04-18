namespace GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.ValueObject;

public sealed record AvailabilityStatusId
{
    public int Value { get; }

    private AvailabilityStatusId(int value)
    {
        Value = value;
    }

    public static AvailabilityStatusId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new AvailabilityStatusId(value);
    }

    public static AvailabilityStatusId CreateEmpty()
    {
        return new AvailabilityStatusId(0);
    }
}
