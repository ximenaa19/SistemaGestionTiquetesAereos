using GestionAerolineas.src.Modules.InvoiceItemTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.InvoiceItemTypes.Application.Services;
using GestionAerolineas.src.Modules.InvoiceItemTypes.Application.UseCases;
using GestionAerolineas.src.Modules.InvoiceItemTypes.Infrastructure.Repository;
using GestionAerolineas.src.Modules.InvoiceItemTypes.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.InvoiceItemTypes;

public static class InvoiceItemTypeModule
{
    public static InvoiceItemTypeMenu Build(AppDbContext context)
    {
        var repository = new InvoiceItemTypeRepository(context);
        IInvoiceItemTypeValidator validator = new InvoiceItemTypeValidator(repository);

        var create = new CreateInvoiceItemTypeUseCase(repository, validator);
        var getAll = new GetAllInvoiceItemTypesUseCase(repository);
        var getById = new GetInvoiceItemTypeByIdUseCase(repository);
        var getByName = new GetInvoiceItemTypeByNameUseCase(repository);
        var update = new UpdateInvoiceItemTypeUseCase(repository, validator);
        var delete = new DeleteInvoiceItemTypeUseCase(repository);

        return new InvoiceItemTypeMenu(
            create,
            getAll,
            getById,
            getByName,
            update,
            delete
        );
    }
}
