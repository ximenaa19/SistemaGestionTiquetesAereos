using System;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObjet;

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
    

    public static Continent Create(ContinentsId id, ContinentName name)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));
        if (name is null) throw new ArgumentNullException(nameof(name));

        return new Continent(id, name);
    }

    public void ChangeName(ContinentName name)
    {
        if (name is null) throw new ArgumentNullException(nameof(name));
        Name = name;
    }
}

