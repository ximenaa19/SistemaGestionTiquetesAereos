using GestionAerolineas.src.Modules.Checkins.Application.Interfaces;
using GestionAerolineas.src.Modules.Checkins.Domain.Aggregate;
using GestionAerolineas.src.Modules.Checkins.Domain.Repositories;
using GestionAerolineas.src.Modules.Checkins.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Checkins.Application.UseCases;

public class GetCheckinByTicketIdUseCase
{
    private readonly ICheckinRepository _repository;
    private readonly ICheckinValidator _validator;

    public GetCheckinByTicketIdUseCase(ICheckinRepository repository, ICheckinValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<Checkin?> ExecuteAsync(int ticketId)
    {
        var ticketIdVO = CheckinTicketId.Create(ticketId);
        await _validator.ValidateTicketExistsAsync(ticketIdVO);
        return await _repository.GetByTicketIdAsync(ticketIdVO);
    }
}
