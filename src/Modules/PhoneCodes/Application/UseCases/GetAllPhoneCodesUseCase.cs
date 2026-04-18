using GestionAerolineas.src.Modules.PhoneCodes.Domain.Aggregate;
using GestionAerolineas.src.Modules.PhoneCodes.Domain.Repositories;

namespace GestionAerolineas.src.Modules.PhoneCodes.Application.UseCases;

public class GetAllPhoneCodesUseCase
{
    private readonly IPhoneCodeRepository _repository;

    public GetAllPhoneCodesUseCase(IPhoneCodeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PhoneCode>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}

