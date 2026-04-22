using GestionAerolineas.src.Modules.Tickets.Application.Interfaces;
using GestionAerolineas.src.Modules.Tickets.Domain.Aggregate;
using GestionAerolineas.src.Modules.Tickets.Domain.Repositories;
using GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Tickets.Application.UseCases;

public class UpdateTicketUseCase
{
    private readonly ITicketRepository _repository;
    private readonly ITicketValidator _validator;

    public UpdateTicketUseCase(ITicketRepository repository, ITicketValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, int reservationPassengerId, string code, DateTime issuedAt, int statusId)
    {
        var idVO = TicketId.Create(id);
        var existing = await _repository.GetByIdAsync(idVO);
        if (existing is null)
            throw new Exception("El ticket no existe");

        var rpIdVO = TicketReservationPassengerId.Create(reservationPassengerId);
        var codeVO = TicketCode.Create(code);
        var issuedAtVO = TicketIssuedAt.Create(issuedAt);
        var statusIdVO = TicketStatusId.Create(statusId);

        await _validator.ValidateReservationPassengerExistsAsync(rpIdVO);
        await _validator.ValidateReservationPassengerIsUniqueAsync(rpIdVO, idVO);
        await _validator.ValidateTicketStatusExistsAsync(statusIdVO);
        await _validator.ValidateTicketCodeUniqueAsync(codeVO, idVO);

        var updated = Ticket.Create(
            idVO,
            rpIdVO,
            codeVO,
            issuedAtVO,
            statusIdVO,
            existing.CreatedAt,
            TicketUpdatedAt.CreateOptional(DateTime.Now));

        await _repository.UpdateAsync(updated);
    }
}

