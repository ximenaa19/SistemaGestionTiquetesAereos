using System;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObjet;

namespace GestionAerolineas.src.Modules.Continents.Domain.Repositories;

public interface IContinentRepository
{
    Task<List<Continent>> GetAllAsync();
    Task<Continent?> GetByIdAsync(ContinentsId id);
    Task AddAsync(Continent continent);
    Task UpdateAsync(Continent continent);
    Task DeleteAsync(ContinentsId id);


}
