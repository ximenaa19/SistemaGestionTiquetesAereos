using System;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Continents.Domain.Aggregate;

public class Continent
{
    public ContinentsId Id { get; private set; }
    public ContinentName Name { get; private set; }

    private Continent(ContinentsId id, ContinentName name)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
    
    public static Continent CreateNew(string name)
    {
        return new Continent(
            ContinentsId.CreateEmpty(),
            ContinentName.Create(name)
        );
    }

    public static Continent FromPersistence(int id, string name)
    {
        return new Continent(
            ContinentsId.Create(id),
            ContinentName.Create(name)
        );
    }


    public void ChangeName(ContinentName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}


