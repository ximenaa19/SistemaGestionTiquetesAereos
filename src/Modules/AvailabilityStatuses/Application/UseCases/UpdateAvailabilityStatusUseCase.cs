using GestionAerolineas.src.Modules.AvailabilityStatuses.Application.Interfaces;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AvailabilityStatuses.Application.UseCases;

public class UpdateAvailabilityStatusUseCase
{
    private readonly IAvailabilityStatusRepository _repository;
    private readonly IAvailabilityStatusValidator _validator;

    public UpdateAvailabilityStatusUseCase(
        IAvailabilityStatusRepository repository,
        IAvailabilityStatusValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, string name)
    {
        var idVO = AvailabilityStatusId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);

        if (existing is null)
            throw new Exception("El estado de disponibilidad no existe");

        var nameVO = AvailabilityStatusName.Create(name);

        await _validator.ValidateNameAsync(nameVO, idVO);

        var updated = AvailabilityStatus.Create(idVO, nameVO);

        await _repository.UpdateAsync(updated);
    }
}
