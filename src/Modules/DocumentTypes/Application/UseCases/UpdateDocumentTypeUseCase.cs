using GestionAerolineas.src.Modules.DocumentTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.DocumentTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.DocumentTypes.Application.UseCases;

public class UpdateDocumentTypeUseCase
{
    private readonly IDocumentTypeRepository _repository;
    private readonly IDocumentTypeValidator _validator;

    public UpdateDocumentTypeUseCase(
        IDocumentTypeRepository repository,
        IDocumentTypeValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, string name, string code)
    {
        var idVO = DocumentTypeId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);

        if (existing is null)
        {
            throw new Exception("El DocumentType no existe");
        }

        var nameVO = DocumentTypeName.Create(name);
        var codeVO = DocumentTypeCode.Create(code);

        await _validator.ValidateAsync(nameVO, codeVO, idVO);

        var updated = DocumentType.Create(idVO, nameVO, codeVO);

        await _repository.UpdateAsync(updated);
    }
}
