using GestionAerolineas.src.Modules.TicketStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.TicketStatuses.Domain.Repositories;

namespace GestionAerolineas.src.Modules.TicketStatuses.Application.UseCases;

public class GetAllTicketStatusesUseCase
{
    private readonly ITicketStatusRepository _repository;

    public GetAllTicketStatusesUseCase(ITicketStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TicketStatus>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
