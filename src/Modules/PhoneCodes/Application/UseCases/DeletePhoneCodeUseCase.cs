using GestionAerolineas.src.Modules.PhoneCodes.Domain.Repositories;
using GestionAerolineas.src.Modules.PhoneCodes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PhoneCodes.Application.UseCases;

public class DeletePhoneCodeUseCase
{
    private readonly IPhoneCodeRepository _repository;

    public DeletePhoneCodeUseCase(IPhoneCodeRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var phoneCodeId = PhoneCodeId.Create(id);
        var phoneCode = await _repository.GetByIdAsync(phoneCodeId);

        if (phoneCode is null)
        {
            throw new KeyNotFoundException($"PhoneCode con id '{phoneCodeId.Value}' no existe.");
        }

        await _repository.DeleteAsync(phoneCode);
    }
}

