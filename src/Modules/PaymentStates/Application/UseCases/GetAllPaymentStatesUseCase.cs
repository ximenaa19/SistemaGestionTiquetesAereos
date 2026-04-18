using GestionAerolineas.src.Modules.PaymentStates.Domain.Aggregate;
using GestionAerolineas.src.Modules.PaymentStates.Domain.Repositories;

namespace GestionAerolineas.src.Modules.PaymentStates.Application.UseCases;

public class GetAllPaymentStatesUseCase
{
    private readonly IPaymentStateRepository _repository;

    public GetAllPaymentStatesUseCase(IPaymentStateRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PaymentState>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
