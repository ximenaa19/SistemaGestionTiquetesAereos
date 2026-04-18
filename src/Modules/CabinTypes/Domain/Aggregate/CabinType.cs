using System;
using GestionAerolineas.src.Modules.CabinTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CabinTypes.Domain.Aggregate;

public class CabinType
{
    public CabinTypesId Id { get; private set; }
    public CabinTypesName Name { get; private set; }
    

    private CabinType(CabinTypesId id, CabinTypesName name)
    {
        Id = id;
        Name = name;
        
    }

    public static CabinType Create(CabinTypesId id, CabinTypesName name)
    {

        return new CabinType(id, name);
    }

}
