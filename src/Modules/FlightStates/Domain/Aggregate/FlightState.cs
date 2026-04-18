using GestionAerolineas.src.Modules.FlightStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightStates.Domain.Aggregate;

public class FlightState
{
    public FlightStateId Id { get; private set; }
    public FlightStateName Name { get; private set; }

    private FlightState(FlightStateId id, FlightStateName name)
    {
        Id = id;
        Name = name;
    }

    public static FlightState Create(FlightStateId id, FlightStateName name)
    {
        return new FlightState(id, name);
    }

    public static FlightState CreateNew(FlightStateName name)
    {
        return new FlightState(FlightStateId.CreateEmpty(), name);
    }
}
