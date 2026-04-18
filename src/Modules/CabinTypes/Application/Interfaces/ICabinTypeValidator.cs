using System;
using GestionAerolineas.src.Modules.CabinTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CabinTypes.Application.Interfaces;

public interface ICabinTypeValidator
{
    Task ValidateNameAsync(CabinTypesName name);

}
