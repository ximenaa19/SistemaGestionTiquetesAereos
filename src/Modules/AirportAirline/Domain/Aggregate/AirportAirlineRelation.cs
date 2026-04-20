using GestionAerolineas.src.Modules.AirportAirline.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AirportAirline.Domain.Aggregate;

public class AirportAirlineRelation
{
    public AirportAirlineId Id { get; private set; }
    public AirportAirlineAirportId AirportId { get; private set; }
    public AirportAirlineAirlineId AirlineId { get; private set; }
    public AirportAirlineTerminal Terminal { get; private set; }
    public AirportAirlineStartDate StartDate { get; private set; }
    public AirportAirlineEndDate EndDate { get; private set; }
    public AirportAirlineIsActive IsActive { get; private set; }

    private AirportAirlineRelation(
        AirportAirlineId id,
        AirportAirlineAirportId airportId,
        AirportAirlineAirlineId airlineId,
        AirportAirlineTerminal terminal,
        AirportAirlineStartDate startDate,
        AirportAirlineEndDate endDate,
        AirportAirlineIsActive isActive)
    {
        Id = id;
        AirportId = airportId;
        AirlineId = airlineId;
        Terminal = terminal;
        StartDate = startDate;
        EndDate = endDate;
        IsActive = isActive;
    }

    public static AirportAirlineRelation Create(
        AirportAirlineId id,
        AirportAirlineAirportId airportId,
        AirportAirlineAirlineId airlineId,
        AirportAirlineTerminal terminal,
        AirportAirlineStartDate startDate,
        AirportAirlineEndDate endDate,
        AirportAirlineIsActive isActive)
    {
        return new AirportAirlineRelation(id, airportId, airlineId, terminal, startDate, endDate, isActive);
    }

    public static AirportAirlineRelation CreateNew(
        AirportAirlineAirportId airportId,
        AirportAirlineAirlineId airlineId,
        AirportAirlineTerminal terminal,
        AirportAirlineStartDate startDate,
        AirportAirlineEndDate endDate,
        AirportAirlineIsActive? isActive = null)
    {
        return new AirportAirlineRelation(
            AirportAirlineId.CreateEmpty(),
            airportId,
            airlineId,
            terminal,
            startDate,
            endDate,
            isActive ?? AirportAirlineIsActive.Create(true)
        );
    }
}

