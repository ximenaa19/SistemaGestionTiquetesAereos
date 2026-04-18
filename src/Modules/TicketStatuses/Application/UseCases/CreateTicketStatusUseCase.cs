using GestionAerolineas.src.Modules.TicketStatuses.Application.Interfaces;
using GestionAerolineas.src.Modules.TicketStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.TicketStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.TicketStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.TicketStatuses.Application.UseCases;

public class CreateTicketStatusUseCase
{
    private readonly ITicketStatusRepository _repository;
    private readonly ITicketStatusValidator _validator;

    public CreateTicketStatusUseCase(
        ITicketStatusRepository repository,
        ITicketStatusValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name)
    {
        var nameVO = TicketStatusName.Create(name);

        await _validator.ValidateNameAsync(nameVO);

        var entity = TicketStatus.CreateNew(nameVO);

        await _repository.AddAsync(entity);
    }
}
