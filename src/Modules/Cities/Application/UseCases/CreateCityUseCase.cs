using GestionAerolineas.src.Modules.Cities.Application.Interfaces;
using GestionAerolineas.src.Modules.Cities.Domain.Aggregate;
using GestionAerolineas.src.Modules.Cities.Domain.Repositories;
using GestionAerolineas.src.Modules.Cities.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Cities.Application.UseCases;

public class CreateCityUseCase
{
    private readonly ICityRepository _repository;
    private readonly ICityValidator _validator;

    public CreateCityUseCase(ICityRepository repository, ICityValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name, int regionId)
    {
        var nameVO = CityName.Create(name);
        var regionVO = CityRegionId.Create(regionId);

        await _validator.ValidateRegionExistsAsync(regionVO);
        await _validator.ValidateNameAsync(nameVO, regionVO);

        var entity = City.CreateNew(nameVO, regionVO);

        await _repository.AddAsync(entity);
    }
}
