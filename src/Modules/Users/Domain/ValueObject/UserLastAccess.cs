namespace GestionAerolineas.src.Modules.Users.Domain.ValueObject;

public sealed record UserLastAccess
{
    public DateTime? Value { get; }

    private UserLastAccess(DateTime? value)
    {
        Value = value;
    }

    public static UserLastAccess Create(DateTime? value)
    {
        return new UserLastAccess(value);
    }
}
