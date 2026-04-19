using GestionAerolineas.src.Modules.CardIssuers.Application.Interfaces;
using GestionAerolineas.src.Modules.CardIssuers.Application.Services;
using GestionAerolineas.src.Modules.CardIssuers.Application.UseCases;
using GestionAerolineas.src.Modules.CardIssuers.Infrastructure.Repository;
using GestionAerolineas.src.Modules.CardIssuers.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.CardIssuers;

public static class CardIssuerModule
{
    public static CardIssuerMenu Build(AppDbContext context)
    {
        var repository = new CardIssuerRepository(context);
        ICardIssuerValidator validator = new CardIssuerValidator(repository);

        var create = new CreateCardIssuerUseCase(repository, validator);
        var getAll = new GetAllCardIssuersUseCase(repository);
        var getById = new GetCardIssuerByIdUseCase(repository);
        var getByName = new GetCardIssuerByNameUseCase(repository);
        var update = new UpdateCardIssuerUseCase(repository, validator);
        var delete = new DeleteCardIssuerUseCase(repository);

        return new CardIssuerMenu(
            create,
            getAll,
            getById,
            getByName,
            update,
            delete
        );
    }
}
