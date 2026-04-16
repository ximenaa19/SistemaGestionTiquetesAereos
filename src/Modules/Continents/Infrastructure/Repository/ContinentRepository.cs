using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.Repositories;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObjet;
using GestionAerolineas.src.Modules.Continents.Infrastructure.Entity;
using GestionAerolineas.src.shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GestionAerolineas.src.Modules.Continents.Infrastructure.Repository;

public sealed class ContinentRepository : IContinentRepository
{
    private readonly AppDbContext _dbContext;

    public ContinentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Continent>> GetAllAsync()
    {
        return await _dbContext.Continents
            .AsNoTracking()
            .Select(entity => ToDomain(entity))
            .ToListAsync();
    }

    public async Task<Continent?> GetByIdAsync(ContinentsId id)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));

        var entity = await _dbContext.Continents
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id.Value);

        return entity is null ? null : ToDomain(entity);
    }

    public async Task AddAsync(Continent continent)
    {
        if (continent is null) throw new ArgumentNullException(nameof(continent));

        var entity = ToEntity(continent);
        await _dbContext.Continents.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Continent continent)
    {
        if (continent is null) throw new ArgumentNullException(nameof(continent));

        var entity = await _dbContext.Continents
            .FirstOrDefaultAsync(x => x.Id == continent.Id.Value);

        if (entity is null)
        {
            throw new InvalidOperationException($"Continente con id {continent.Id.Value} no encontrado.");
        }

        entity.Name = continent.Name.Value;
        _dbContext.Continents.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(ContinentsId id)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));

        var entity = await _dbContext.Continents
            .FirstOrDefaultAsync(x => x.Id == id.Value);

        if (entity is null)
        {
            return;
        }

        _dbContext.Continents.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    private static Continent ToDomain(ContinentEntity entity)
    {
        return Continent.Create(
            ContinentsId.Create(entity.Id),
            ContinentName.Create(entity.Name!) );
    }

    private static ContinentEntity ToEntity(Continent continent)
    {
        return new ContinentEntity
        {
            Id = continent.Id.Value,
            Name = continent.Name.Value
        };
    }
}
