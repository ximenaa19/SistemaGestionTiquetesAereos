using GestionAerolineas.src.Modules.EmailDomains.Domain.Repositories;
using GestionAerolineas.src.Modules.EmailDomains.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.EmailDomains.Application.UseCases;

public class DeleteEmailDomainUseCase
{
    private readonly IEmailDomainRepository _repository;

    public DeleteEmailDomainUseCase(IEmailDomainRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var emailDomainId = EmailDomainId.Create(id);
        var emailDomain = await _repository.GetByIdAsync(emailDomainId);

        if (emailDomain is null)
        {
            throw new KeyNotFoundException($"EmailDomain con id '{emailDomainId.Value}' no existe.");
        }

        await _repository.DeleteAsync(emailDomain);
    }
}

