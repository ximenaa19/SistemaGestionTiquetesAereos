namespace GestionAerolineas.src.Modules.Users.Domain.ValueObject;

public sealed record UserIsActive
{
    public bool Value { get; }

    private UserIsActive(bool value)
    {
        Value = value;
    }

    public static UserIsActive Create(bool value)
    {
        return new UserIsActive(value);
    }
}
