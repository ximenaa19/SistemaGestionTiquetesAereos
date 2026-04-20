using GestionAerolineas.src.Modules.FlightStates.Application.UseCases;
using GestionAerolineas.src.Modules.FlightStates.Infrastructure.Repository;
using GestionAerolineas.src.Modules.FlightStatusTransitions.Application.Interfaces;
using GestionAerolineas.src.Modules.FlightStatusTransitions.Application.Services;
using GestionAerolineas.src.Modules.FlightStatusTransitions.Application.UseCases;
using GestionAerolineas.src.Modules.FlightStatusTransitions.Infrastructure.Repository;
using GestionAerolineas.src.Modules.FlightStatusTransitions.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.FlightStatusTransitions;

public static class FlightStatusTransitionModule
{
    public static FlightStatusTransitionMenu Build(AppDbContext context)
    {
        var transitionRepository = new FlightStatusTransitionRepository(context);
        IFlightStatusTransitionValidator validator = new FlightStatusTransitionValidator(transitionRepository);

        var create = new CreateFlightStatusTransitionUseCase(transitionRepository, validator);
        var getAll = new GetAllFlightStatusTransitionsUseCase(transitionRepository);
        var getById = new GetFlightStatusTransitionByIdUseCase(transitionRepository);
        var getByPair = new GetFlightStatusTransitionByPairUseCase(transitionRepository);
        var update = new UpdateFlightStatusTransitionUseCase(transitionRepository, validator);
        var delete = new DeleteFlightStatusTransitionUseCase(transitionRepository);

        var flightStateRepository = new FlightStateRepository(context);
        var getAllFlightStates = new GetAllFlightStatesUseCase(flightStateRepository);
        var getFlightStateByName = new GetFlightStateByNameUseCase(flightStateRepository);

        return new FlightStatusTransitionMenu(
            create,
            getAll,
            getById,
            getByPair,
            update,
            delete,
            getAllFlightStates,
            getFlightStateByName
        );
    }
}

