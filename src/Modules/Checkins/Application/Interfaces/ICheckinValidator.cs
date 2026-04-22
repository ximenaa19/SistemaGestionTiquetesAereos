using GestionAerolineas.src.Modules.Checkins.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Checkins.Application.Interfaces;

public interface ICheckinValidator
{
    Task ValidateTicketExistsAsync(CheckinTicketId ticketId);
    Task ValidateTicketUniqueAsync(CheckinTicketId ticketId, CheckinId? excludingId = null);
    Task ValidateStaffExistsAsync(CheckinStaffId staffId);
    Task ValidateStaffIsActiveAirportStaffAsync(CheckinStaffId staffId);
    Task ValidateFlightSeatExistsAsync(CheckinFlightSeatId flightSeatId);
    Task ValidateFlightSeatIsAvailableAsync(CheckinFlightSeatId flightSeatId, CheckinId? excludingId = null);
    Task ValidateStatusExistsAsync(CheckinStatusId statusId);
    Task ValidateBoardingPassUniqueAsync(CheckinBoardingPassNumber boardingPass, CheckinId? excludingId = null);
    Task ValidateSeatBelongsToTicketFlightAsync(CheckinTicketId ticketId, CheckinFlightSeatId flightSeatId);
    Task ValidateBaggageAsync(CheckinHasHoldBaggage hasHoldBaggage, CheckinBaggageWeightKg baggageWeightKg);
}

