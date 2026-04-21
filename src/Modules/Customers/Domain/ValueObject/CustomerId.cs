namespace GestionAerolineas.src.Modules.Customers.Domain.ValueObject;

public sealed record CustomerId
{
    public int Value { get; }

    private CustomerId(int value)
    {
        Value = value;
    }

    public static CustomerId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new CustomerId(value);
    }

    public static CustomerId CreateEmpty()
    {
        return new CustomerId(0);
    }
}
