using System;
using System.Collections.Generic;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;
using GestionAerolineas.src.Modules.Continents.Infrastructure.Entity;

namespace GestionAerolineas.src.Modules.Continents.Domain.Repositories;

public interface IContinentRepository
{
    Task<ContinentEntity> AddAsync(Continent continent, CancellationToken cancellationToken = default);
    Task<Continent?> FindByIdAsync(ContinentsId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Continent>> FindAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(Continent continent, CancellationToken cancellationToken = default);
    Task<bool> DeleteByIdAsync(ContinentsId id, CancellationToken cancellationToken = default);
}

