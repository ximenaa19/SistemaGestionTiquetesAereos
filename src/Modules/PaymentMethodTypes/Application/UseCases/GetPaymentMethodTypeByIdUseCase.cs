using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentMethodTypes.Application.UseCases;

public class GetPaymentMethodTypeByIdUseCase
{
    private readonly IPaymentMethodTypeRepository _repository;

    public GetPaymentMethodTypeByIdUseCase(IPaymentMethodTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaymentMethodType?> ExecuteAsync(int id)
    {
        var idVO = PaymentMethodTypeId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}
