using GestionAerolineas.src.Modules.Aircraft.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Aircraft.Domain.Aggregate;

public class AircraftAggregate
{
    public AircraftId Id { get; private set; }
    public AircraftModelId ModelId { get; private set; }
    public AircraftAirlineId AirlineId { get; private set; }
    public AircraftRegistration Registration { get; private set; }
    public AircraftManufactureDate ManufactureDate { get; private set; }
    public AircraftIsActive IsActive { get; private set; }

    private AircraftAggregate(
        AircraftId id,
        AircraftModelId modelId,
        AircraftAirlineId airlineId,
        AircraftRegistration registration,
        AircraftManufactureDate manufactureDate,
        AircraftIsActive isActive)
    {
        Id = id;
        ModelId = modelId;
        AirlineId = airlineId;
        Registration = registration;
        ManufactureDate = manufactureDate;
        IsActive = isActive;
    }

    public static AircraftAggregate Create(
        AircraftId id,
        AircraftModelId modelId,
        AircraftAirlineId airlineId,
        AircraftRegistration registration,
        AircraftManufactureDate manufactureDate,
        AircraftIsActive isActive)
    {
        return new AircraftAggregate(id, modelId, airlineId, registration, manufactureDate, isActive);
    }

    public static AircraftAggregate CreateNew(
        AircraftModelId modelId,
        AircraftAirlineId airlineId,
        AircraftRegistration registration,
        AircraftManufactureDate manufactureDate,
        AircraftIsActive? isActive = null)
    {
        return new AircraftAggregate(
            AircraftId.CreateEmpty(),
            modelId,
            airlineId,
            registration,
            manufactureDate,
            isActive ?? AircraftIsActive.Create(true)
        );
    }
}

