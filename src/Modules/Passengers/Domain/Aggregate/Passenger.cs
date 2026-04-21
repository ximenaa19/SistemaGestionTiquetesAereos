using GestionAerolineas.src.Modules.Passengers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Passengers.Domain.Aggregate;

public class Passenger
{
    public PassengerId Id { get; private set; }
    public PassengerPersonId PersonId { get; private set; }
    public PassengerTypeId PassengerTypeId { get; private set; }

    private Passenger(PassengerId id, PassengerPersonId personId, PassengerTypeId passengerTypeId)
    {
        Id = id;
        PersonId = personId;
        PassengerTypeId = passengerTypeId;
    }

    public static Passenger Create(PassengerId id, PassengerPersonId personId, PassengerTypeId passengerTypeId)
    {
        return new Passenger(id, personId, passengerTypeId);
    }

    public static Passenger CreateNew(PassengerPersonId personId, PassengerTypeId passengerTypeId)
    {
        return new Passenger(PassengerId.CreateEmpty(), personId, passengerTypeId);
    }
}
