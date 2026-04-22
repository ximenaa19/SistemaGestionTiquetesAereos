using GestionAerolineas.src.Modules.Tickets.Domain.Repositories;
using GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Tickets.Application.UseCases;

public class DeleteTicketUseCase
{
    private readonly ITicketRepository _repository;

    public DeleteTicketUseCase(ITicketRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var idVO = TicketId.Create(id);
        var existing = await _repository.GetByIdAsync(idVO);
        if (existing is null)
            throw new Exception("El ticket no existe");

        await _repository.DeleteAsync(existing);
    }
}

