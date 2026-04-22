using GestionAerolineas.src.Modules.Checkins.Domain.Aggregate;
using GestionAerolineas.src.Modules.Checkins.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Checkins.Application.UseCases;

public class GetCheckinsByCheckedAtRangeUseCase
{
    private readonly ICheckinRepository _repository;

    public GetCheckinsByCheckedAtRangeUseCase(ICheckinRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Checkin>> ExecuteAsync(DateTime fromInclusive, DateTime toInclusive)
    {
        if (fromInclusive > toInclusive)
            throw new Exception("El rango de fechas no es valido");

        return _repository.GetByCheckedAtRangeAsync(fromInclusive, toInclusive);
    }
}

