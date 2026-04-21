using GestionAerolineas.src.Modules.Payments.Domain.Aggregate;
using GestionAerolineas.src.Modules.Payments.Domain.Repositories;
using GestionAerolineas.src.Modules.Payments.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Payments.Application.UseCases;

public class GetPaymentsByReservationIdUseCase
{
    private readonly IPaymentRepository _repository;

    public GetPaymentsByReservationIdUseCase(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Payment>> ExecuteAsync(int reservationId)
    {
        return _repository.GetByReservationIdAsync(PaymentReservationId.Create(reservationId));
    }
}

