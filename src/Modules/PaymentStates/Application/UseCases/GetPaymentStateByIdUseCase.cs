using GestionAerolineas.src.Modules.PaymentStates.Domain.Aggregate;
using GestionAerolineas.src.Modules.PaymentStates.Domain.Repositories;
using GestionAerolineas.src.Modules.PaymentStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentStates.Application.UseCases;

public class GetPaymentStateByIdUseCase
{
    private readonly IPaymentStateRepository _repository;

    public GetPaymentStateByIdUseCase(IPaymentStateRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaymentState?> ExecuteAsync(int id)
    {
        var idVO = PaymentStateId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}
