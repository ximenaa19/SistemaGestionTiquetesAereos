using GestionAerolineas.src.Modules.PaymentStates.Application.Interfaces;
using GestionAerolineas.src.Modules.PaymentStates.Application.Services;
using GestionAerolineas.src.Modules.PaymentStates.Application.UseCases;
using GestionAerolineas.src.Modules.PaymentStates.Infrastructure.Repository;
using GestionAerolineas.src.Modules.PaymentStates.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.PaymentStates;

public static class PaymentStateModule
{
    public static PaymentStateMenu Build(AppDbContext context)
    {
        var repository = new PaymentStateRepository(context);
        IPaymentStateValidator validator = new PaymentStateValidator(repository);

        var create = new CreatePaymentStateUseCase(repository, validator);
        var getAll = new GetAllPaymentStatesUseCase(repository);
        var getById = new GetPaymentStateByIdUseCase(repository);
        var getByName = new GetPaymentStateByNameUseCase(repository);
        var update = new UpdatePaymentStateUseCase(repository, validator);
        var delete = new DeletePaymentStateUseCase(repository);

        return new PaymentStateMenu(
            create,
            getAll,
            getById,
            getByName,
            update,
            delete
        );
    }
}
