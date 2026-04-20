using GestionAerolineas.src.Modules.Countries.Domain.ValueObject;
using GestionAerolineas.src.Modules.Countries.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Regions.Application.Interfaces;
using GestionAerolineas.src.Modules.Regions.Domain.Repositories;
using GestionAerolineas.src.Modules.Regions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Regions.Application.Services;

public class RegionValidator : IRegionValidator
{
    private readonly IRegionRepository _repository;
    private readonly CountryRepository _countryRepository;

    public RegionValidator(IRegionRepository repository, CountryRepository countryRepository)
    {
        _repository = repository;
        _countryRepository = countryRepository;
    }

    public async Task ValidateCountryExistsAsync(RegionCountryId countryId)
    {
        var exists = await _countryRepository.ExistsAsync(CountryId.Create(countryId.Value));
        if (!exists)
            throw new Exception("El país no existe");
    }

    public async Task ValidateNameAsync(RegionName name, RegionCountryId countryId, RegionId? currentId = null)
    {
        var normalizedCandidate = RegionName.Normalize(name.Value);
        var exists = await _repository.ExistsByNormalizedNameInCountryAsync(
            normalizedCandidate,
            countryId.Value,
            currentId?.Value);

        if (exists)
            throw new Exception("Ya existe una región con ese nombre para este país");
    }
}
