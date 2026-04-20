using GestionAerolineas.src.Modules.PaymentMethods.Domain.Repositories;
using GestionAerolineas.src.Modules.PaymentMethods.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentMethods.Application.UseCases;

public class DeletePaymentMethodUseCase
{
    private readonly IPaymentMethodRepository _repository;

    public DeletePaymentMethodUseCase(IPaymentMethodRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var idVO = PaymentMethodId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);
        if (existing is null)
            throw new Exception("El método de pago no existe");

        await _repository.DeleteAsync(existing);
    }
}

