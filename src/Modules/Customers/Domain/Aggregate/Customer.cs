using GestionAerolineas.src.Modules.Customers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Customers.Domain.Aggregate;

public class Customer
{
    public CustomerId Id { get; private set; }
    public CustomerPersonId PersonId { get; private set; }
    public CustomerCreatedAt CreatedAt { get; private set; }

    private Customer(CustomerId id, CustomerPersonId personId, CustomerCreatedAt createdAt)
    {
        Id = id;
        PersonId = personId;
        CreatedAt = createdAt;
    }

    public static Customer Create(CustomerId id, CustomerPersonId personId, CustomerCreatedAt createdAt)
    {
        return new Customer(id, personId, createdAt);
    }

    public static Customer CreateNew(CustomerPersonId personId)
    {
        return new Customer(CustomerId.CreateEmpty(), personId, CustomerCreatedAt.CreateNow());
    }
}
