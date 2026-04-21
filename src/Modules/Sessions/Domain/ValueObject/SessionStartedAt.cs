namespace GestionAerolineas.src.Modules.Sessions.Domain.ValueObject;

public sealed record SessionStartedAt
{
    public DateTime Value { get; }

    private SessionStartedAt(DateTime value)
    {
        Value = value;
    }

    public static SessionStartedAt Create(DateTime? value)
    {
        if (!value.HasValue)
            throw new ArgumentException("La fecha de inicio es obligatoria");

        return new SessionStartedAt(value.Value);
    }
}
