using GestionAerolineas.src.Modules.InvoiceItemTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.InvoiceItemTypes.Application.UseCases;

public class CreateInvoiceItemTypeUseCase
{
    private readonly IInvoiceItemTypeRepository _repository;
    private readonly IInvoiceItemTypeValidator _validator;

    public CreateInvoiceItemTypeUseCase(
        IInvoiceItemTypeRepository repository,
        IInvoiceItemTypeValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name)
    {
        var nameVO = InvoiceItemTypeName.Create(name);

        await _validator.ValidateNameAsync(nameVO);

        var entity = InvoiceItemType.CreateNew(nameVO);

        await _repository.AddAsync(entity);
    }
}
