using GestionAerolineas.src.Modules.Countries.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Countries.Application.Interfaces;

public interface ICountryValidator
{
    Task ValidateIsoCodeAsync(CountryCodigoIso isoCode, CountryId? currentId = null);
    Task ValidateContinentExistsAsync(CountryContinentId continentId);
}

