using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.Repositories;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;
using GestionAerolineas.src.Modules.Continents.Infrastructure.Entity;
using GestionAerolineas.src.shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GestionAerolineas.src.Modules.Continents.Infrastructure.Repository;

public sealed class ContinentRepository : IContinentRepository
{
    private readonly AppDbContext _dbContext;

    public ContinentRepository(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task<ContinentEntity> AddAsync(Continent continent, CancellationToken cancellationToken = default)
    {
        var entity = new ContinentEntity { Name = continent.Name.Value };
        await _dbContext.Continents.AddAsync(entity, cancellationToken);
        return entity;
    }

    public async Task<Continent?> FindByIdAsync(ContinentsId id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Continents
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id.Value, cancellationToken);
        return entity is null ? null : Continent.FromPersistence(entity.Id, entity.Name!);
    }

    public async Task<IReadOnlyCollection<Continent>> FindAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _dbContext.Continents
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
        return entities.Select(x => Continent.FromPersistence(x.Id, x.Name!)).ToList();
    }

    public async Task UpdateAsync(Continent continent, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Continents
            .FirstOrDefaultAsync(x => x.Id == continent.Id.Value, cancellationToken)
            ?? throw new KeyNotFoundException($"Continente con id '{continent.Id.Value}' no encontrado.");
        entity.Name = continent.Name.Value;
    }

    public async Task<bool> DeleteByIdAsync(ContinentsId id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Continents
            .FirstOrDefaultAsync(x => x.Id == id.Value, cancellationToken);
        if (entity is null) return false;
        _dbContext.Continents.Remove(entity);
        return true;
    }
}

