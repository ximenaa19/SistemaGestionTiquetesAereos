using GestionAerolineas.src.Modules.PaymentStates.Application.Interfaces;
using GestionAerolineas.src.Modules.PaymentStates.Domain.Repositories;
using GestionAerolineas.src.Modules.PaymentStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentStates.Application.Services;

public class PaymentStateValidator : IPaymentStateValidator
{
    private readonly IPaymentStateRepository _repository;

    public PaymentStateValidator(IPaymentStateRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateNameAsync(PaymentStateName name, PaymentStateId? currentId = null)
    {
        var normalizedCandidate = PaymentStateName.Normalize(name.Value);
        var all = await _repository.GetAllAsync();

        foreach (var item in all)
        {
            if (currentId != null && item.Id.Value == currentId.Value)
                continue;

            if (PaymentStateName.Normalize(item.Name.Value) == normalizedCandidate)
                throw new Exception("Ya existe un estado de pago con ese nombre");
        }
    }
}
