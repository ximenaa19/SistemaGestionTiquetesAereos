using GestionAerolineas.src.Modules.TicketStatuses.Application.Interfaces;
using GestionAerolineas.src.Modules.TicketStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.TicketStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.TicketStatuses.Application.Services;

public class TicketStatusValidator : ITicketStatusValidator
{
    private readonly ITicketStatusRepository _repository;

    public TicketStatusValidator(ITicketStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateNameAsync(TicketStatusName name, TicketStatusId? currentId = null)
    {
        var existingByName = await _repository.GetByNameAsync(name);

        if (existingByName is not null && existingByName.Id != currentId)
            throw new Exception("Ya existe un estado de tiquete con ese nombre");
    }
}
