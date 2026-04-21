using GestionAerolineas.src.Modules.Payments.Domain.Aggregate;
using GestionAerolineas.src.Modules.Payments.Domain.Repositories;
using GestionAerolineas.src.Modules.Payments.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Payments.Application.UseCases;

public class GetPaymentsByMethodIdUseCase
{
    private readonly IPaymentRepository _repository;

    public GetPaymentsByMethodIdUseCase(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Payment>> ExecuteAsync(int methodId)
    {
        return _repository.GetByMethodIdAsync(PaymentMethodId.Create(methodId));
    }
}

