using GestionAerolineas.src.Modules.EmailDomains.Application.Interfaces;
using GestionAerolineas.src.Modules.EmailDomains.Domain.Repositories;
using GestionAerolineas.src.Modules.EmailDomains.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.EmailDomains.Application.Services;

public class EmailDomainValidator : IEmailDomainValidator
{
    private readonly IEmailDomainRepository _repository;

    public EmailDomainValidator(IEmailDomainRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateDomainAsync(EmailDomainValue domain)
    {
        var existing = await _repository.GetByDomainAsync(domain);

        if (existing != null)
            throw new Exception("Ya existe un EmailDomain con ese dominio");
    }
}

