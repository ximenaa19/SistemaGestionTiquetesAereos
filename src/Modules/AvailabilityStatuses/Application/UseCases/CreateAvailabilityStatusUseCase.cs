using GestionAerolineas.src.Modules.AvailabilityStatuses.Application.Interfaces;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AvailabilityStatuses.Application.UseCases;

public class CreateAvailabilityStatusUseCase
{
    private readonly IAvailabilityStatusRepository _repository;
    private readonly IAvailabilityStatusValidator _validator;

    public CreateAvailabilityStatusUseCase(
        IAvailabilityStatusRepository repository,
        IAvailabilityStatusValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name)
    {
        var nameVO = AvailabilityStatusName.Create(name);

        await _validator.ValidateNameAsync(nameVO);

        var entity = AvailabilityStatus.CreateNew(nameVO);

        await _repository.AddAsync(entity);
    }
}
