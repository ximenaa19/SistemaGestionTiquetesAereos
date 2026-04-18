using GestionAerolineas.src.Modules.PaymentStates.Domain.Repositories;
using GestionAerolineas.src.Modules.PaymentStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentStates.Application.UseCases;

public class DeletePaymentStateUseCase
{
    private readonly IPaymentStateRepository _repository;

    public DeletePaymentStateUseCase(IPaymentStateRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var paymentStateId = PaymentStateId.Create(id);
        var paymentState = await _repository.GetByIdAsync(paymentStateId);

        if (paymentState is null)
            throw new KeyNotFoundException($"PaymentState con id '{paymentStateId.Value}' no existe.");

        await _repository.DeleteAsync(paymentState);
    }
}
