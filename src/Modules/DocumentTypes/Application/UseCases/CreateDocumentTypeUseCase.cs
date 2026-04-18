using GestionAerolineas.src.Modules.DocumentTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.DocumentTypes.Application.UseCases;

public class CreateDocumentTypeUseCase
{
    private readonly IDocumentTypeRepository _repository;
    private readonly IDocumentTypeValidator _validator;

    public CreateDocumentTypeUseCase(
        IDocumentTypeRepository repository,
        IDocumentTypeValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name, string code)
    {
        var nameVO = DocumentTypeName.Create(name);
        var codeVO = DocumentTypeCode.Create(code);

        await _validator.ValidateAsync(nameVO, codeVO);

        var documentType = DocumentType.Create(nameVO, codeVO);

        await _repository.AddAsync(documentType);
    }
}
