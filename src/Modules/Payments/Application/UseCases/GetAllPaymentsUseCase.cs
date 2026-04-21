using GestionAerolineas.src.Modules.Payments.Domain.Aggregate;
using GestionAerolineas.src.Modules.Payments.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Payments.Application.UseCases;

public class GetAllPaymentsUseCase
{
    private readonly IPaymentRepository _repository;

    public GetAllPaymentsUseCase(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Payment>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

