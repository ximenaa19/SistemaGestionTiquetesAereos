using GestionAerolineas.src.Modules.Cities.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Cities.Domain.Aggregate;

public class City
{
    public CityId Id { get; private set; }
    public CityName Name { get; private set; }
    public CityRegionId RegionId { get; private set; }

    private City(CityId id, CityName name, CityRegionId regionId)
    {
        Id = id;
        Name = name;
        RegionId = regionId;
    }

    public static City Create(CityId id, CityName name, CityRegionId regionId)
    {
        return new City(id, name, regionId);
    }
}


