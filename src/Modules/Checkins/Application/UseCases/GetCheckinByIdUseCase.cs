using GestionAerolineas.src.Modules.Checkins.Domain.Aggregate;
using GestionAerolineas.src.Modules.Checkins.Domain.Repositories;
using GestionAerolineas.src.Modules.Checkins.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Checkins.Application.UseCases;

public class GetCheckinByIdUseCase
{
    private readonly ICheckinRepository _repository;

    public GetCheckinByIdUseCase(ICheckinRepository repository)
    {
        _repository = repository;
    }

    public Task<Checkin?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(CheckinId.Create(id));
    }
}

