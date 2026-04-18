using GestionAerolineas.src.Modules.EmailDomains.Domain.Aggregate;
using GestionAerolineas.src.Modules.EmailDomains.Domain.Repositories;

namespace GestionAerolineas.src.Modules.EmailDomains.Application.UseCases;

public class GetAllEmailDomainsUseCase
{
    private readonly IEmailDomainRepository _repository;

    public GetAllEmailDomainsUseCase(IEmailDomainRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EmailDomain>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}

