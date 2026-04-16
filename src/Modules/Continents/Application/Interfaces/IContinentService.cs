using System.Collections.Generic;
using System.Threading.Tasks;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObjet;

namespace GestionAerolineas.src.Modules.Continents.Application.Interfaces;

public interface IContinentService
{
    Task<List<Continent>> GetAllAsync();
    Task<Continent?> GetByIdAsync(ContinentsId id);
    Task CreateAsync(ContinentsId id, ContinentName name);
    Task UpdateAsync(ContinentsId id, ContinentName name);
    Task DeleteAsync(ContinentsId id);
}
