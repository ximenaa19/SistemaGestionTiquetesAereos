namespace GestionAerolineas.src.Modules.Users.Domain.ValueObject;

public sealed record UserId
{
    public int Value { get; }

    private UserId(int value)
    {
        Value = value;
    }

    public static UserId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new UserId(value);
    }

    public static UserId CreateEmpty()
    {
        return new UserId(0);
    }
}
