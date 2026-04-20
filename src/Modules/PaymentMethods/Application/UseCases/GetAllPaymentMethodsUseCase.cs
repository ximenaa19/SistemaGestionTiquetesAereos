using GestionAerolineas.src.Modules.PaymentMethods.Domain.Aggregate;
using GestionAerolineas.src.Modules.PaymentMethods.Domain.Repositories;

namespace GestionAerolineas.src.Modules.PaymentMethods.Application.UseCases;

public class GetAllPaymentMethodsUseCase
{
    private readonly IPaymentMethodRepository _repository;

    public GetAllPaymentMethodsUseCase(IPaymentMethodRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<PaymentMethod>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

