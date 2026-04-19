using GestionAerolineas.src.Modules.PaymentMethodTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentMethodTypes.Application.Services;

public class PaymentMethodTypeValidator : IPaymentMethodTypeValidator
{
    private readonly IPaymentMethodTypeRepository _repository;

    public PaymentMethodTypeValidator(IPaymentMethodTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateNameAsync(PaymentMethodTypeName name)
    {
        var existing = await _repository.GetByNameAsync(name);

        if (existing != null)
            throw new Exception("Ya existe un PaymentMethodType con ese nombre");
    }
}
