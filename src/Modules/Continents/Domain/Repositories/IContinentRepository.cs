using System;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Continents.Domain.Repositories;

public interface IContinentRepository
{
   Task AddAsync(Continent continent, CancellationToken cancellationToken = default);
    Task<Continent?> FindByIdAsync(ContinentsId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Continent>> FindAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(Continent continent, CancellationToken cancellationToken = default);
    Task<bool> DeleteByIdAsync(ContinentsId id, CancellationToken cancellationToken = default);


}

