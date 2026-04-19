using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.Repositories;

namespace GestionAerolineas.src.Modules.PaymentMethodTypes.Application.UseCases;

public class GetAllPaymentMethodTypesUseCase
{
    private readonly IPaymentMethodTypeRepository _repository;

    public GetAllPaymentMethodTypesUseCase(IPaymentMethodTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PaymentMethodType>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
