using GestionAerolineas.src.Modules.EmailDomains.Domain.Aggregate;
using GestionAerolineas.src.Modules.EmailDomains.Domain.Repositories;
using GestionAerolineas.src.Modules.EmailDomains.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.EmailDomains.Application.UseCases;

public class GetEmailDomainByDomainUseCase
{
    private readonly IEmailDomainRepository _repository;

    public GetEmailDomainByDomainUseCase(IEmailDomainRepository repository)
    {
        _repository = repository;
    }

    public async Task<EmailDomain?> ExecuteAsync(string domain)
    {
        var domainVO = EmailDomainValue.Create(domain);
        return await _repository.GetByDomainAsync(domainVO);
    }
}

