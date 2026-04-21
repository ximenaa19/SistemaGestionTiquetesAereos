using GestionAerolineas.src.Modules.Payments.Domain.Aggregate;
using GestionAerolineas.src.Modules.Payments.Domain.Repositories;
using GestionAerolineas.src.Modules.Payments.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Payments.Application.UseCases;

public class GetPaymentByIdUseCase
{
    private readonly IPaymentRepository _repository;

    public GetPaymentByIdUseCase(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public Task<Payment?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(PaymentId.Create(id));
    }
}

