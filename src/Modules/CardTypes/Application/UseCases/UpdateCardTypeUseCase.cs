using GestionAerolineas.src.Modules.CardTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.CardTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.CardTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.CardTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardTypes.Application.UseCases;

public class UpdateCardTypeUseCase
{
    private readonly ICardTypeRepository _repository;
    private readonly ICardTypeValidator _validator;

    public UpdateCardTypeUseCase(
        ICardTypeRepository repository,
        ICardTypeValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, string name)
    {
        var idVO = CardTypeId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);

        if (existing is null)
            throw new Exception("El tipo de tarjeta no existe");

        var nameVO = CardTypeName.Create(name);

        await _validator.ValidateNameAsync(nameVO, idVO);

        var updated = CardType.Create(idVO, nameVO);

        await _repository.UpdateAsync(updated);
    }
}
