using GestionAerolineas.src.Modules.EmailDomains.Domain.Aggregate;
using GestionAerolineas.src.Modules.EmailDomains.Domain.Repositories;
using GestionAerolineas.src.Modules.EmailDomains.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.EmailDomains.Application.UseCases;

public class GetEmailDomainByIdUseCase
{
    private readonly IEmailDomainRepository _repository;

    public GetEmailDomainByIdUseCase(IEmailDomainRepository repository)
    {
        _repository = repository;
    }

    public async Task<EmailDomain?> ExecuteAsync(int id)
    {
        var idVO = EmailDomainId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}

