namespace GestionAerolineas.src.Modules.Customers.Domain.ValueObject;

public sealed record CustomerPersonId
{
    public int Value { get; }

    private CustomerPersonId(int value)
    {
        Value = value;
    }

    public static CustomerPersonId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new CustomerPersonId(value);
    }
}
