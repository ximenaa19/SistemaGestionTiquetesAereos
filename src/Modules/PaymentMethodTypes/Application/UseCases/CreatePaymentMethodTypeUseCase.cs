using GestionAerolineas.src.Modules.PaymentMethodTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentMethodTypes.Application.UseCases;

public class CreatePaymentMethodTypeUseCase
{
    private readonly IPaymentMethodTypeRepository _repository;
    private readonly IPaymentMethodTypeValidator _validator;

    public CreatePaymentMethodTypeUseCase(
        IPaymentMethodTypeRepository repository,
        IPaymentMethodTypeValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name)
    {
        var nameVO = PaymentMethodTypeName.Create(name);

        await _validator.ValidateNameAsync(nameVO);

        var entity = PaymentMethodType.CreateNew(nameVO);

        await _repository.AddAsync(entity);
    }
}
