using GestionAerolineas.src.Modules.Countries.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Countries.Domain.Aggregate;

public class Country
{
    public CountryId Id { get; private set; }
    public CountryName Name { get; private set; }
    public CountryCodigoIso IsoCode { get; private set; }
    public CountryContinentId ContinentId { get; private set; }

    private Country(CountryId id, CountryName name, CountryCodigoIso isoCode, CountryContinentId continentId)
    {
        Id = id;
        Name = name;
        IsoCode = isoCode;
        ContinentId = continentId;
    }

    public static Country Create(CountryId id, CountryName name, CountryCodigoIso isoCode, CountryContinentId continentId)
    {
        return new Country(id, name, isoCode, continentId);
    }

    public static Country CreateNew(CountryName name, CountryCodigoIso isoCode, CountryContinentId continentId)
    {
        return new Country(CountryId.CreateEmpty(), name, isoCode, continentId);
    }
}

