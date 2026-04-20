using GestionAerolineas.src.Modules.AircraftModels.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AircraftModels.Application.Interfaces;

public interface IAircraftModelValidator
{
    Task ValidateManufacturerExistsAsync(AircraftManufacturerId manufacturerId);
    Task ValidateModelNameAsync(AircraftModelName modelName, AircraftModelId? currentId = null);
}

