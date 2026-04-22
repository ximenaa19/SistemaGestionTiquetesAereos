using GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Tickets.Application.Interfaces;

public interface ITicketValidator
{
    Task ValidateReservationPassengerExistsAsync(TicketReservationPassengerId reservationPassengerId);
    Task ValidateReservationPassengerIsUniqueAsync(TicketReservationPassengerId reservationPassengerId, TicketId? excludingId = null);
    Task ValidateTicketStatusExistsAsync(TicketStatusId statusId);
    Task ValidateReservationIsConfirmadaAsync(TicketReservationPassengerId reservationPassengerId);
    Task ValidateTicketCodeUniqueAsync(TicketCode code, TicketId? excludingId = null);
}

