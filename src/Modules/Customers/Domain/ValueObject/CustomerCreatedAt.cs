namespace GestionAerolineas.src.Modules.Customers.Domain.ValueObject;

public sealed record CustomerCreatedAt
{
    public DateTime Value { get; }

    private CustomerCreatedAt(DateTime value)
    {
        Value = value;
    }

    public static CustomerCreatedAt Create(DateTime value)
    {
        return new CustomerCreatedAt(value);
    }

    public static CustomerCreatedAt Create(DateTime? value)
    {
        return new CustomerCreatedAt(value ?? DateTime.Now);
    }

    public static CustomerCreatedAt CreateNow()
    {
        return new CustomerCreatedAt(DateTime.Now);
    }
}
