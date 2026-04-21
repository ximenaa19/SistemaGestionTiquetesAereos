namespace GestionAerolineas.src.Modules.Users.Domain.ValueObject;

public sealed record UserPersonId
{
    public int? Value { get; }

    private UserPersonId(int? value)
    {
        Value = value;
    }

    public static UserPersonId Create(int? value)
    {
        if (!value.HasValue)
            return new UserPersonId((int?)null);

        if (value.Value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new UserPersonId(value.Value);
    }
}
