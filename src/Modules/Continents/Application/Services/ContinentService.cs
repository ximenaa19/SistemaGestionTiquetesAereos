using System;
using GestionAerolineas.src.Modules.Continents.Application.Interfaces;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.Repositories;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;
using GestionAerolineas.src.shared.Contracts;

namespace GestionAerolineas.src.Modules.Continents.Application.Services;

public class ContinentService : IContinentService
{
    private readonly IContinentRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ContinentService(IContinentRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Continent> CreateAsync(string name, CancellationToken cancellationToken = default)
    {
        var continent = Continent.CreateNew(name);
        await _repository.AddAsync(continent, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return continent;
    }

    public Task<Continent?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => _repository.FindByIdAsync(ContinentsId.Create(id), cancellationToken);

    public Task<IReadOnlyCollection<Continent>> GetAllAsync(CancellationToken cancellationToken = default)
        => _repository.FindAllAsync(cancellationToken);

    public async Task<Continent> UpdateAsync(int id, string name, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.FindByIdAsync(ContinentsId.Create(id), cancellationToken)
            ?? throw new KeyNotFoundException($"Continente con id '{id}' no encontrado.");

        existing.ChangeName(ContinentName.Create(name));
        await _repository.UpdateAsync(existing, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return existing;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var deleted = await _repository.DeleteByIdAsync(ContinentsId.Create(id), cancellationToken);
        if (!deleted) return false;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
    
}


