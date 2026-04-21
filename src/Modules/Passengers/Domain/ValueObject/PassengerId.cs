namespace GestionAerolineas.src.Modules.Passengers.Domain.ValueObject;

public sealed record PassengerId
{
    public int Value { get; }

    private PassengerId(int value)
    {
        Value = value;
    }

    public static PassengerId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new PassengerId(value);
    }

    public static PassengerId CreateEmpty()
    {
        return new PassengerId(0);
    }
}
