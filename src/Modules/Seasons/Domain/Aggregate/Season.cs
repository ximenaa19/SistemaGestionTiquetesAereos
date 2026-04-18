using GestionAerolineas.src.Modules.Seasons.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Seasons.Domain.Aggregate;

public class Season
{
    public SeasonId Id { get; private set; }
    public SeasonName Name { get; private set; }
    public SeasonDescription Description { get; private set; }
    public SeasonPriceFactor PriceFactor { get; private set; }

    private Season(SeasonId id, SeasonName name, SeasonDescription description, SeasonPriceFactor priceFactor)
    {
        Id = id;
        Name = name;
        Description = description;
        PriceFactor = priceFactor;
    }

    public static Season Create(SeasonId id, SeasonName name, SeasonDescription description, SeasonPriceFactor priceFactor)
    {
        return new Season(id, name, description, priceFactor);
    }

    public static Season CreateNew(SeasonName name, SeasonDescription description, SeasonPriceFactor priceFactor)
    {
        return new Season(SeasonId.CreateEmpty(), name, description, priceFactor);
    }
}
