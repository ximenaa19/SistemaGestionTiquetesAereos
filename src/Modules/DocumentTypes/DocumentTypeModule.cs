using GestionAerolineas.src.Modules.DocumentTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.DocumentTypes.Application.Services;
using GestionAerolineas.src.Modules.DocumentTypes.Application.UseCases;
using GestionAerolineas.src.Modules.DocumentTypes.Infrastructure.Repository;
using GestionAerolineas.src.Modules.DocumentTypes.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.DocumentTypes;

public static class DocumentTypeModule
{
    public static DocumentTypeMenu Build(AppDbContext context)
    {
        var repository = new DocumentTypeRepository(context);
        IDocumentTypeValidator validator = new DocumentTypeValidator(repository);

        var create = new CreateDocumentTypeUseCase(repository, validator);
        var getAll = new GetAllDocumentTypesUseCase(repository);
        var getById = new GetDocumentTypeByIdUseCase(repository);
        var getByCode = new GetDocumentTypeByCodeUseCase(repository);
        var update = new UpdateDocumentTypeUseCase(repository, validator);
        var delete = new DeleteDocumentTypeUseCase(repository);

        return new DocumentTypeMenu(
            create,
            getAll,
            getById,
            getByCode,
            update,
            delete
        );
    }
}
