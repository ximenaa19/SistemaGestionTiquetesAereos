using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentMethodTypes.Application.UseCases;

public class GetPaymentMethodTypeByNameUseCase
{
    private readonly IPaymentMethodTypeRepository _repository;

    public GetPaymentMethodTypeByNameUseCase(IPaymentMethodTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaymentMethodType?> ExecuteAsync(string name)
    {
        var nameVO = PaymentMethodTypeName.Create(name);
        return await _repository.GetByNameAsync(nameVO);
    }
}
