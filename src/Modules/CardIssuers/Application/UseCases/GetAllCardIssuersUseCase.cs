using GestionAerolineas.src.Modules.CardIssuers.Domain.Aggregate;
using GestionAerolineas.src.Modules.CardIssuers.Domain.Repositories;

namespace GestionAerolineas.src.Modules.CardIssuers.Application.UseCases;

public class GetAllCardIssuersUseCase
{
    private readonly ICardIssuerRepository _repository;

    public GetAllCardIssuersUseCase(ICardIssuerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CardIssuer>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
