using GestionAerolineas.src.Modules.CardIssuers.Domain.Aggregate;
using GestionAerolineas.src.Modules.CardIssuers.Domain.Repositories;
using GestionAerolineas.src.Modules.CardIssuers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardIssuers.Application.UseCases;

public class GetCardIssuerByNameUseCase
{
    private readonly ICardIssuerRepository _repository;

    public GetCardIssuerByNameUseCase(ICardIssuerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CardIssuer?> ExecuteAsync(string name)
    {
        var nameVO = CardIssuerName.Create(name);
        return await _repository.GetByNameAsync(nameVO);
    }
}
