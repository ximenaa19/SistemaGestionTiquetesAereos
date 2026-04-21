namespace GestionAerolineas.src.Modules.Sessions.Domain.ValueObject;

public sealed record SessionId
{
    public int Value { get; }

    private SessionId(int value)
    {
        Value = value;
    }

    public static SessionId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id debe ser mayor a 0");

        return new SessionId(value);
    }

    public static SessionId CreateEmpty()
    {
        return new SessionId(0);
    }
}
