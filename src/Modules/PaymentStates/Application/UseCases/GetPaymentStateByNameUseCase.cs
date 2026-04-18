using GestionAerolineas.src.Modules.PaymentStates.Domain.Aggregate;
using GestionAerolineas.src.Modules.PaymentStates.Domain.Repositories;
using GestionAerolineas.src.Modules.PaymentStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentStates.Application.UseCases;

public class GetPaymentStateByNameUseCase
{
    private readonly IPaymentStateRepository _repository;

    public GetPaymentStateByNameUseCase(IPaymentStateRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaymentState?> ExecuteAsync(string name)
    {
        var nameVO = PaymentStateName.Create(name);
        return await _repository.GetByNameAsync(nameVO);
    }
}
