using GestionAerolineas.src.Modules.FlightStates.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightStates.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightStates.Domain.ValueObject;
using GestionAerolineas.src.Modules.FlightStates.Infrastructure.Entity;
using GestionAerolineas.src.shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GestionAerolineas.src.Modules.FlightStates.Infrastructure.Repository;

public class FlightStateRepository : IFlightStateRepository
{
    private readonly AppDbContext _context;

    public FlightStateRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FlightState>> GetAllAsync()
    {
        var entities = await _context.FlightStates.AsNoTracking().ToListAsync();
        return entities.Select(MapToDomain).ToList();
    }

    public async Task<FlightState?> GetByIdAsync(FlightStateId id)
    {
        var entity = await _context.FlightStates
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id.Value);

        return entity is null ? null : MapToDomain(entity);
    }

    public async Task<FlightState?> GetByNameAsync(FlightStateName name)
    {
        var normalized = FlightStateName.Normalize(name.Value);
        var entities = await _context.FlightStates.AsNoTracking().ToListAsync();

        var match = entities.FirstOrDefault(e => FlightStateName.Normalize(e.Name ?? string.Empty) == normalized);

        return match is null ? null : MapToDomain(match);
    }

    public async Task AddAsync(FlightState flightState)
    {
        await _context.FlightStates.AddAsync(MapToEntity(flightState));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FlightState flightState)
    {
        var existing = await _context.FlightStates
            .FirstOrDefaultAsync(e => e.Id == flightState.Id.Value);

        if (existing is null)
            return;

        existing.Name = flightState.Name.Value;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(FlightState flightState)
    {
        var entity = await _context.FlightStates.FindAsync(flightState.Id.Value);

        if (entity is null)
            return;

        _context.FlightStates.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public Task<bool> ExistsAsync(FlightStateId id)
    {
        return _context.FlightStates.AnyAsync(e => e.Id == id.Value);
    }

    private static FlightState MapToDomain(FlightStateEntity entity)
    {
        return FlightState.Create(
            FlightStateId.Create(entity.Id),
            FlightStateName.Create(entity.Name ?? string.Empty)
        );
    }

    private static FlightStateEntity MapToEntity(FlightState flightState)
    {
        return new FlightStateEntity
        {
            Id = flightState.Id.Value,
            Name = flightState.Name.Value
        };
    }
}
