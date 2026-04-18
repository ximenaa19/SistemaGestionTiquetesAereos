using GestionAerolineas.src.Modules.PhoneCodes.Domain.Aggregate;
using GestionAerolineas.src.Modules.PhoneCodes.Domain.Repositories;
using GestionAerolineas.src.Modules.PhoneCodes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PhoneCodes.Application.UseCases;

public class GetPhoneCodeByCountryNameUseCase
{
    private readonly IPhoneCodeRepository _repository;

    public GetPhoneCodeByCountryNameUseCase(IPhoneCodeRepository repository)
    {
        _repository = repository;
    }

    public async Task<PhoneCode?> ExecuteAsync(string countryName)
    {
        var nameVO = CountryName.Create(countryName);
        return await _repository.GetByCountryNameAsync(nameVO);
    }
}

