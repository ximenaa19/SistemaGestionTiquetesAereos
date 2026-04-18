using GestionAerolineas.src.Modules.PhoneCodes.Application.Interfaces;
using GestionAerolineas.src.Modules.PhoneCodes.Domain.Aggregate;
using GestionAerolineas.src.Modules.PhoneCodes.Domain.Repositories;
using GestionAerolineas.src.Modules.PhoneCodes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PhoneCodes.Application.UseCases;

public class UpdatePhoneCodeUseCase
{
    private readonly IPhoneCodeRepository _repository;
    private readonly IPhoneCodeValidator _validator;

    public UpdatePhoneCodeUseCase(
        IPhoneCodeRepository repository,
        IPhoneCodeValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, string countryCode, string countryName)
    {
        var idVO = PhoneCodeId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);

        if (existing == null)
            throw new Exception("El PhoneCode no existe");

        var codeVO = PhoneCountryCode.Create(countryCode);
        var nameVO = CountryName.Create(countryName);

        await _validator.ValidateCountryCodeAsync(codeVO, idVO);

        var updated = PhoneCode.Create(idVO, codeVO, nameVO);

        await _repository.UpdateAsync(updated);
    }
}

