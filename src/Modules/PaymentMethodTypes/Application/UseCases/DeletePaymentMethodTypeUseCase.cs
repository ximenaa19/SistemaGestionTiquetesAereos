using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentMethodTypes.Application.UseCases;

public class DeletePaymentMethodTypeUseCase
{
    private readonly IPaymentMethodTypeRepository _repository;

    public DeletePaymentMethodTypeUseCase(IPaymentMethodTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var paymentMethodTypeId = PaymentMethodTypeId.Create(id);
        var paymentMethodType = await _repository.GetByIdAsync(paymentMethodTypeId);

        if (paymentMethodType is null)
        {
            throw new KeyNotFoundException($"PaymentMethodType con id '{paymentMethodTypeId.Value}' no existe.");
        }

        await _repository.DeleteAsync(paymentMethodType);
    }
}
