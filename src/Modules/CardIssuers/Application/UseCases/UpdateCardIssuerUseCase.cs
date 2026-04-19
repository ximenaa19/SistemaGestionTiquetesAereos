using GestionAerolineas.src.Modules.CardIssuers.Application.Interfaces;
using GestionAerolineas.src.Modules.CardIssuers.Domain.Aggregate;
using GestionAerolineas.src.Modules.CardIssuers.Domain.Repositories;
using GestionAerolineas.src.Modules.CardIssuers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardIssuers.Application.UseCases;

public class UpdateCardIssuerUseCase
{
    private readonly ICardIssuerRepository _repository;
    private readonly ICardIssuerValidator _validator;

    public UpdateCardIssuerUseCase(
        ICardIssuerRepository repository,
        ICardIssuerValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, string name)
    {
        var idVO = CardIssuerId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);

        if (existing == null)
            throw new Exception("El CardIssuer no existe");

        var nameVO = CardIssuerName.Create(name);

        await _validator.ValidateNameAsync(nameVO);

        var updated = CardIssuer.Create(idVO, nameVO);

        await _repository.UpdateAsync(updated);
    }
}
