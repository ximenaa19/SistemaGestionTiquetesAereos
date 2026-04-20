using GestionAerolineas.src.Modules.Airlines.Application.Interfaces;
using GestionAerolineas.src.Modules.Airlines.Domain.Aggregate;
using GestionAerolineas.src.Modules.Airlines.Domain.Repositories;
using GestionAerolineas.src.Modules.Airlines.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Airlines.Application.UseCases;

public class CreateAirlineUseCase
{
    private readonly IAirlineRepository _repository;
    private readonly IAirlineValidator _validator;

    public CreateAirlineUseCase(IAirlineRepository repository, IAirlineValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name, string iataCode, int originCountryId, bool isActive = true)
    {
        var nameVO = AirlineName.Create(name);
        var iataVO = AirlineIataCode.Create(iataCode);
        var originCountryVO = AirlineOriginCountryId.Create(originCountryId);
        var isActiveVO = AirlineIsActive.Create(isActive);

        await _validator.ValidateOriginCountryExistsAsync(originCountryVO);
        await _validator.ValidateNameAsync(nameVO, originCountryVO);
        await _validator.ValidateIataCodeAsync(iataVO);

        var entity = Airline.CreateNew(nameVO, iataVO, originCountryVO, isActiveVO);
        await _repository.AddAsync(entity);
    }
}

