using GestionAerolineas.src.Modules.CardTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.CardTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardTypes.Application.UseCases;

public class DeleteCardTypeUseCase
{
    private readonly ICardTypeRepository _repository;

    public DeleteCardTypeUseCase(ICardTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var cardTypeId = CardTypeId.Create(id);
        var cardType = await _repository.GetByIdAsync(cardTypeId);

        if (cardType is null)
            throw new KeyNotFoundException($"CardType con id '{cardTypeId.Value}' no existe.");

        await _repository.DeleteAsync(cardType);
    }
}
