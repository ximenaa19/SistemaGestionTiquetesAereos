using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.Repositories;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;
using GestionAerolineas.src.Modules.Continents.Infrastructure.Entity;
using GestionAerolineas.src.shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GestionAerolineas.src.Modules.Continents.Infrastructure.Repository;

public class ContinentRepository : IContinentRepository
{
    private readonly AppDbContext _context;

    public ContinentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Continent>> GetAllAsync()
    {
        var entities = await _context.Continents.AsNoTracking().ToListAsync();
        return entities.Select(MapToDomain);
    }

    public async Task<Continent?> GetByIdAsync(ContinentId id)
    {
        var entity = await _context.Continents
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id.Value);

        return entity is null ? null : MapToDomain(entity);
    }

    public async Task<Continent?> GetByNameAsync(ContinentName name)
    {
        var entity = await _context.Continents
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Name == name.Value);

        return entity is null ? null : MapToDomain(entity);
    }

    public async Task AddAsync(Continent entity)
    {
        await _context.Continents.AddAsync(MapToEntity(entity));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Continent entity)
    {
        _context.Continents.Update(MapToEntity(entity));
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ContinentId id)
    {
        var entity = await _context.Continents.FindAsync(id.Value);

        if (entity is null) return;

        _context.Continents.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(ContinentId id)
    {
        return await _context.Continents.AnyAsync(e => e.Id == id.Value);
    }

    private static Continent MapToDomain(ContinentEntity entity)
    {
        return Continent.Create(
            ContinentId.Create(entity.Id),
            ContinentName.Create(entity.Name ?? "")
        );
    }

    private static ContinentEntity MapToEntity(Continent entity)
    {
        return new ContinentEntity
        {
            Id = entity.Id.Value,
            Name = entity.Name.Value
        };
    }
}