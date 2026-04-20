namespace GestionAerolineas.src.Modules.FlightStatusTransitions.Infrastructure.Entity;

public class FlightStatusTransitionEntity
{
    public int Id { get; set; }
    public int OriginStateId { get; set; }
    public int DestinationStateId { get; set; }
}

