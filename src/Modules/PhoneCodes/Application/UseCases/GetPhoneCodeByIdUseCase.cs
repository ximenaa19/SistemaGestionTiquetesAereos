using GestionAerolineas.src.Modules.PhoneCodes.Domain.Aggregate;
using GestionAerolineas.src.Modules.PhoneCodes.Domain.Repositories;
using GestionAerolineas.src.Modules.PhoneCodes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PhoneCodes.Application.UseCases;

public class GetPhoneCodeByIdUseCase
{
    private readonly IPhoneCodeRepository _repository;

    public GetPhoneCodeByIdUseCase(IPhoneCodeRepository repository)
    {
        _repository = repository;
    }

    public async Task<PhoneCode?> ExecuteAsync(int id)
    {
        var idVO = PhoneCodeId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}

