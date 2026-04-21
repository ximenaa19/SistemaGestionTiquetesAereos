namespace GestionAerolineas.src.Modules.Sessions.Domain.ValueObject;

public sealed record SessionEndedAt
{
    public DateTime? Value { get; }

    private SessionEndedAt(DateTime? value)
    {
        Value = value;
    }

    public static SessionEndedAt Create(DateTime? value)
    {
        return new SessionEndedAt(value);
    }
}
