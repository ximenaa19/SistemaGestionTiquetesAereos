using System;
using GestionAerolineas.src.shared.Context;
using Microsoft.EntityFrameworkCore;
using GestionAerolineas.src.Modules.RoadTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.RoadTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.RoadTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.RoadTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RoadTypes.Infrastructure.Repository;

public class RoadTypeRepository : IRoadTypeRepository
{
    private readonly AppDbContext _context;

    public RoadTypeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RoadType>> GetAllAsync()
    {
        var entities = await _context.RoadTypes
            .AsNoTracking()
            .ToListAsync();

        return entities.Select(MapToDomain).ToList();
    }

    public async Task<RoadType?> GetByIdAsync(RoadTypeId id)
    {
        var entity = await _context.RoadTypes
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id.Value);

        return entity is null ? null : MapToDomain(entity);
    }

    public async Task<RoadType?> GetByNameAsync(RoadTypeName name)
    {
        var entity = await _context.RoadTypes
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Name == name.Value);

        return entity is null ? null : MapToDomain(entity);
    }

    public async Task AddAsync(RoadType roadType)
    {
        await _context.RoadTypes.AddAsync(MapToEntity(roadType));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(RoadType roadType)
    {
        _context.RoadTypes.Update(MapToEntity(roadType));
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(RoadType roadType)
    {
        var entity = await _context.RoadTypes.FindAsync(roadType.Id.Value);

        if (entity is null)
        {
            return;
        }

        _context.RoadTypes.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(RoadTypeId id)
    {
        return await _context.RoadTypes.AnyAsync(e => e.Id == id.Value);
    }

    private static RoadType MapToDomain(RoadTypeEntity entity)
    {
        return RoadType.Create(
            RoadTypeId.Create(entity.Id),
            RoadTypeName.Create(entity.Name ?? string.Empty)
        );
    }

    private static RoadTypeEntity MapToEntity(RoadType roadType)
    {
        return new RoadTypeEntity
        {
            Id = roadType.Id.Value,
            Name = roadType.Name.Value
        };
    }
}
