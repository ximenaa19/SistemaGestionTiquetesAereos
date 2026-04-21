namespace GestionAerolineas.src.Modules.Users.Domain.ValueObject;

public sealed record UserUpdatedAt
{
    public DateTime Value { get; }

    private UserUpdatedAt(DateTime value)
    {
        Value = value;
    }

    public static UserUpdatedAt Create(DateTime value)
    {
        return new UserUpdatedAt(value);
    }

    public static UserUpdatedAt Create(DateTime? value)
    {
        return new UserUpdatedAt(value ?? DateTime.Now);
    }
}
