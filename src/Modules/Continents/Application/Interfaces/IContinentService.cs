using System.Collections.Generic;
using System.Threading.Tasks;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Continents.Application.Interfaces;

public interface IContinentService
{
    Task<Continent> CreateAsync(string name, CancellationToken cancellationToken = default);
    Task<Continent?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Continent>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Continent> UpdateAsync(int id, string name, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}

