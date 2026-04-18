using GestionAerolineas.src.Modules.EmailDomains.Application.Interfaces;
using GestionAerolineas.src.Modules.EmailDomains.Domain.Aggregate;
using GestionAerolineas.src.Modules.EmailDomains.Domain.Repositories;
using GestionAerolineas.src.Modules.EmailDomains.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.EmailDomains.Application.UseCases;

public class UpdateEmailDomainUseCase
{
    private readonly IEmailDomainRepository _repository;
    private readonly IEmailDomainValidator _validator;

    public UpdateEmailDomainUseCase(
        IEmailDomainRepository repository,
        IEmailDomainValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, string domain)
    {
        var idVO = EmailDomainId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);

        if (existing == null)
            throw new Exception("El EmailDomain no existe");

        var domainVO = EmailDomainValue.Create(domain);

        await _validator.ValidateDomainAsync(domainVO);

        var updated = EmailDomain.Create(idVO, domainVO);

        await _repository.UpdateAsync(updated);
    }
}

