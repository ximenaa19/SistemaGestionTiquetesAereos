using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Continents.Domain.Aggregate;

public class Continent
{
    public ContinentId Id { get; private set; }
    public ContinentName Name { get; private set; }

    private Continent(ContinentId id, ContinentName name)
    {
        Id = id;
        Name = name;
    }

    public static Continent Create(ContinentId id, ContinentName name)
    {
        return new Continent(id, name);
    }
}


