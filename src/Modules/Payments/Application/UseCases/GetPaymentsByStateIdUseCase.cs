using GestionAerolineas.src.Modules.Payments.Domain.Aggregate;
using GestionAerolineas.src.Modules.Payments.Domain.Repositories;
using GestionAerolineas.src.Modules.Payments.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Payments.Application.UseCases;

public class GetPaymentsByStateIdUseCase
{
    private readonly IPaymentRepository _repository;

    public GetPaymentsByStateIdUseCase(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Payment>> ExecuteAsync(int stateId)
    {
        return _repository.GetByStateIdAsync(PaymentStateId.Create(stateId));
    }
}

