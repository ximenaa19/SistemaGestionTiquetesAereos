namespace GestionAerolineas.src.Modules.ReservationPassengers.Infrastructure.Entity;

public class ReservationPassengerEntity
{
    public int Id { get; set; }
    public int ReservationFlightId { get; set; }
    public int PassengerId { get; set; }
}

