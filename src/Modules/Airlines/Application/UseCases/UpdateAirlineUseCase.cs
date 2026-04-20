using GestionAerolineas.src.Modules.Airlines.Application.Interfaces;
using GestionAerolineas.src.Modules.Airlines.Domain.Aggregate;
using GestionAerolineas.src.Modules.Airlines.Domain.Repositories;
using GestionAerolineas.src.Modules.Airlines.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Airlines.Application.UseCases;

public class UpdateAirlineUseCase
{
    private readonly IAirlineRepository _repository;
    private readonly IAirlineValidator _validator;

    public UpdateAirlineUseCase(IAirlineRepository repository, IAirlineValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, string name, string iataCode, int originCountryId, bool isActive)
    {
        var idVO = AirlineId.Create(id);
        var nameVO = AirlineName.Create(name);
        var iataVO = AirlineIataCode.Create(iataCode);
        var originCountryVO = AirlineOriginCountryId.Create(originCountryId);
        var isActiveVO = AirlineIsActive.Create(isActive);

        await _validator.ValidateOriginCountryExistsAsync(originCountryVO);
        await _validator.ValidateNameAsync(nameVO, originCountryVO, idVO);
        await _validator.ValidateIataCodeAsync(iataVO, idVO);

        var entity = Airline.Create(idVO, nameVO, iataVO, originCountryVO, isActiveVO);
        await _repository.UpdateAsync(entity);
    }
}

