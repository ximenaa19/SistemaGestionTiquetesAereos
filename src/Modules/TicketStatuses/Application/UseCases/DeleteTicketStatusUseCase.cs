using GestionAerolineas.src.Modules.TicketStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.TicketStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.TicketStatuses.Application.UseCases;

public class DeleteTicketStatusUseCase
{
    private readonly ITicketStatusRepository _repository;

    public DeleteTicketStatusUseCase(ITicketStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var ticketStatusId = TicketStatusId.Create(id);
        var ticketStatus = await _repository.GetByIdAsync(ticketStatusId);

        if (ticketStatus is null)
            throw new KeyNotFoundException($"TicketStatus con id '{ticketStatusId.Value}' no existe.");

        await _repository.DeleteAsync(ticketStatus);
    }
}
