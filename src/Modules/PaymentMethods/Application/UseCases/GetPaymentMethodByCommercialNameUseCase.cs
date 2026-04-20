using GestionAerolineas.src.Modules.PaymentMethods.Domain.Aggregate;
using GestionAerolineas.src.Modules.PaymentMethods.Domain.Repositories;
using GestionAerolineas.src.Modules.PaymentMethods.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentMethods.Application.UseCases;

public class GetPaymentMethodByCommercialNameUseCase
{
    private readonly IPaymentMethodRepository _repository;

    public GetPaymentMethodByCommercialNameUseCase(IPaymentMethodRepository repository)
    {
        _repository = repository;
    }

    public Task<PaymentMethod?> ExecuteAsync(string commercialName)
    {
        var nameVO = PaymentMethodCommercialName.Create(commercialName);
        return _repository.GetByCommercialNameAsync(nameVO);
    }
}

