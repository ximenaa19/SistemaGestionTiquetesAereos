using GestionAerolineas.src.Modules.CabinConfiguration.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CabinConfiguration.Application.Interfaces;

public interface ICabinConfigurationValidator
{
    Task ValidateAircraftExistsAsync(CabinConfigurationAircraftId aircraftId);
    Task ValidateCabinTypeExistsAsync(CabinConfigurationCabinTypeId cabinTypeId);
    Task ValidateUniqueCabinTypeInAircraftAsync(CabinConfigurationAircraftId aircraftId, CabinConfigurationCabinTypeId cabinTypeId, CabinConfigurationId? currentId = null);
    Task ValidateRowRangeAsync(CabinConfigurationStartRow startRow, CabinConfigurationEndRow endRow);
    Task ValidateSeatsAndLettersAsync(CabinConfigurationSeatsPerRow seatsPerRow, CabinConfigurationSeatLetters seatLetters);
    Task ValidateNoRowOverlapAsync(CabinConfigurationAircraftId aircraftId, CabinConfigurationStartRow startRow, CabinConfigurationEndRow endRow, CabinConfigurationId? currentId = null);
}

