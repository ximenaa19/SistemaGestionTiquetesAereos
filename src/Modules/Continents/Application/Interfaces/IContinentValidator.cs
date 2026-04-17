using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Continents.Application.Interfaces;

public interface IContinentValidator
{
    Task ValidateAsync(ContinentName name);
}