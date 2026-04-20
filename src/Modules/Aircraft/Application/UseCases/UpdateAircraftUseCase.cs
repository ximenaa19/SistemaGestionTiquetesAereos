using GestionAerolineas.src.Modules.Aircraft.Application.Interfaces;
using GestionAerolineas.src.Modules.Aircraft.Domain.Aggregate;
using GestionAerolineas.src.Modules.Aircraft.Domain.Repositories;
using GestionAerolineas.src.Modules.Aircraft.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Aircraft.Application.UseCases;

public class UpdateAircraftUseCase
{
    private readonly IAircraftRepository _repository;
    private readonly IAircraftValidator _validator;

    public UpdateAircraftUseCase(IAircraftRepository repository, IAircraftValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, int modelId, int airlineId, string registration, DateTime? manufactureDate, bool isActive)
    {
        var idVO = AircraftId.Create(id);
        var modelIdVO = AircraftModelId.Create(modelId);
        var airlineIdVO = AircraftAirlineId.Create(airlineId);
        var registrationVO = AircraftRegistration.Create(registration);
        var manufactureDateVO = AircraftManufactureDate.Create(manufactureDate);
        var isActiveVO = AircraftIsActive.Create(isActive);

        await _validator.ValidateModelExistsAsync(modelIdVO);
        await _validator.ValidateAirlineExistsAsync(airlineIdVO);
        await _validator.ValidateRegistrationAsync(registrationVO, idVO);

        var entity = AircraftAggregate.Create(idVO, modelIdVO, airlineIdVO, registrationVO, manufactureDateVO, isActiveVO);
        await _repository.UpdateAsync(entity);
    }
}

