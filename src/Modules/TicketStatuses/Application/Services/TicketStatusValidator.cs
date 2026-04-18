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
        var normalizedCandidate = TicketStatusName.Normalize(name.Value);
        var all = await _repository.GetAllAsync();

        foreach (var item in all)
        {
            if (currentId != null && item.Id.Value == currentId.Value)
                continue;

            if (TicketStatusName.Normalize(item.Name.Value) == normalizedCandidate)
                throw new Exception("Ya existe un estado de tiquete con ese nombre");
        }
    }
}
