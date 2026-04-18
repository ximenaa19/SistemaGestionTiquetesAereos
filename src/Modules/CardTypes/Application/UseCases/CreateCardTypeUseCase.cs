using GestionAerolineas.src.Modules.CardTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.CardTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.CardTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.CardTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardTypes.Application.UseCases;

public class CreateCardTypeUseCase
{
    private readonly ICardTypeRepository _repository;
    private readonly ICardTypeValidator _validator;

    public CreateCardTypeUseCase(
        ICardTypeRepository repository,
        ICardTypeValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name)
    {
        var nameVO = CardTypeName.Create(name);

        await _validator.ValidateNameAsync(nameVO);

        var entity = CardType.CreateNew(nameVO);

        await _repository.AddAsync(entity);
    }
}
