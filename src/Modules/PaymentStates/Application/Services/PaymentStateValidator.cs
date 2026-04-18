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
        var existingByName = await _repository.GetByNameAsync(name);

        if (existingByName is not null && existingByName.Id != currentId)
            throw new Exception("Ya existe un estado de pago con ese nombre");
    }
}
