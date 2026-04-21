namespace GestionAerolineas.src.Modules.Passengers.Domain.ValueObject;

public sealed record PassengerPersonId
{
    public int Value { get; }

    private PassengerPersonId(int value)
    {
        Value = value;
    }

    public static PassengerPersonId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new PassengerPersonId(value);
    }
}
