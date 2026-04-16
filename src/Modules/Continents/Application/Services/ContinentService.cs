using System;
using GestionAerolineas.src.Modules.Continents.Application.Interfaces;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.Repositories;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObjet;

namespace GestionAerolineas.src.Modules.Continents.Application.Services;

public class ContinentService : IContinentService
{
    private readonly IContinentRepository _repository;

    public ContinentService(IContinentRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Continent>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Continent?> GetByIdAsync(ContinentsId id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateAsync(ContinentsId id, ContinentName name)
    {
        // La validación ocurre en el dominio y en los objetos de valor.
        var continent = Continent.Create(id, name);
        await _repository.AddAsync(continent);
    }

    public async Task UpdateAsync(ContinentsId id, ContinentName name)
    {
        var continent = await _repository.GetByIdAsync(id)
            ?? throw new Exception($"Continente con id {id} no encontrado.");

        continent.ChangeName(name);
        await _repository.UpdateAsync(continent);
    }

    public async Task DeleteAsync(ContinentsId id)
    {
        await _repository.DeleteAsync(id);
    }
}

