namespace GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

public record TicketReservationPassengerId(int Value)
{
    public static TicketReservationPassengerId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("reserva_pasajero_id no es valido");
        return new TicketReservationPassengerId(value);
    }
}

