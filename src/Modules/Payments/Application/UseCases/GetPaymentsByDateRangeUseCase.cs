using GestionAerolineas.src.Modules.Payments.Domain.Aggregate;
using GestionAerolineas.src.Modules.Payments.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Payments.Application.UseCases;

public class GetPaymentsByDateRangeUseCase
{
    private readonly IPaymentRepository _repository;

    public GetPaymentsByDateRangeUseCase(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Payment>> ExecuteAsync(DateTime fromInclusive, DateTime toInclusive)
    {
        return _repository.GetByPaidAtRangeAsync(fromInclusive, toInclusive);
    }
}

