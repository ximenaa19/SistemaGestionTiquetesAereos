using GestionAerolineas.src.Modules.CardIssuers.Domain.Aggregate;
using GestionAerolineas.src.Modules.CardIssuers.Domain.Repositories;
using GestionAerolineas.src.Modules.CardIssuers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardIssuers.Application.UseCases;

public class GetCardIssuerByIdUseCase
{
    private readonly ICardIssuerRepository _repository;

    public GetCardIssuerByIdUseCase(ICardIssuerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CardIssuer?> ExecuteAsync(int id)
    {
        var idVO = CardIssuerId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}
