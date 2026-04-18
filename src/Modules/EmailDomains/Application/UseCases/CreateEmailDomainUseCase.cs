using GestionAerolineas.src.Modules.EmailDomains.Application.Interfaces;
using GestionAerolineas.src.Modules.EmailDomains.Domain.Aggregate;
using GestionAerolineas.src.Modules.EmailDomains.Domain.Repositories;
using GestionAerolineas.src.Modules.EmailDomains.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.EmailDomains.Application.UseCases;

public class CreateEmailDomainUseCase
{
    private readonly IEmailDomainRepository _repository;
    private readonly IEmailDomainValidator _validator;

    public CreateEmailDomainUseCase(
        IEmailDomainRepository repository,
        IEmailDomainValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string domain)
    {
        var domainVO = EmailDomainValue.Create(domain);

        await _validator.ValidateDomainAsync(domainVO);

        var entity = EmailDomain.CreateNew(domainVO);

        await _repository.AddAsync(entity);
    }
}

