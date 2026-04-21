namespace GestionAerolineas.src.Modules.Users.Domain.ValueObject;

public sealed record UserCreatedAt
{
    public DateTime Value { get; }

    private UserCreatedAt(DateTime value)
    {
        Value = value;
    }

    public static UserCreatedAt Create(DateTime value)
    {
        return new UserCreatedAt(value);
    }

    public static UserCreatedAt Create(DateTime? value)
    {
        return new UserCreatedAt(value ?? DateTime.Now);
    }
}
