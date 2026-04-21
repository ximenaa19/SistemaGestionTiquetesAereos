namespace GestionAerolineas.src.Modules.Sessions.Domain.ValueObject;

public sealed record SessionIsActive
{
    public bool Value { get; }

    private SessionIsActive(bool value)
    {
        Value = value;
    }

    public static SessionIsActive Create(bool value)
    {
        return new SessionIsActive(value);
    }
}
