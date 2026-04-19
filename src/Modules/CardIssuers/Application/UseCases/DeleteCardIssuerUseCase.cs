using GestionAerolineas.src.Modules.CardIssuers.Domain.Repositories;
using GestionAerolineas.src.Modules.CardIssuers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardIssuers.Application.UseCases;

public class DeleteCardIssuerUseCase
{
    private readonly ICardIssuerRepository _repository;

    public DeleteCardIssuerUseCase(ICardIssuerRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var cardIssuerId = CardIssuerId.Create(id);
        var cardIssuer = await _repository.GetByIdAsync(cardIssuerId);

        if (cardIssuer is null)
        {
            throw new KeyNotFoundException($"CardIssuer con id '{cardIssuerId.Value}' no existe.");
        }

        await _repository.DeleteAsync(cardIssuer);
    }
}
