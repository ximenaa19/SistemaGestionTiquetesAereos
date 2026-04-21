namespace GestionAerolineas.src.Modules.Sessions.Domain.ValueObject;

public sealed record SessionUserId
{
    public int Value { get; }

    private SessionUserId(int value)
    {
        Value = value;
    }

    public static SessionUserId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El user_id debe ser mayor a 0");

        return new SessionUserId(value);
    }
}
