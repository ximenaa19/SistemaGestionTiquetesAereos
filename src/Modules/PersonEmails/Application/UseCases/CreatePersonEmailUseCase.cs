using GestionAerolineas.src.Modules.PersonEmails.Application.Interfaces;
using GestionAerolineas.src.Modules.PersonEmails.Domain.Aggregate;
using GestionAerolineas.src.Modules.PersonEmails.Domain.Repositories;
using GestionAerolineas.src.Modules.PersonEmails.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PersonEmails.Application.UseCases;

public class CreatePersonEmailUseCase
{
    private readonly IPersonEmailRepository _repository;
    private readonly IPersonEmailValidator _validator;

    public CreatePersonEmailUseCase(IPersonEmailRepository repository, IPersonEmailValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int personId, string user, int emailDomainId, bool isPrimary = false)
    {
        var personIdVO = PersonEmailPersonId.Create(personId);
        var userVO = PersonEmailUser.Create(user);
        var domainIdVO = PersonEmailDomainId.Create(emailDomainId);
        var primaryVO = PersonEmailIsPrimary.Create(isPrimary);

        await _validator.ValidatePersonExistsAsync(personIdVO);
        await _validator.ValidateEmailDomainExistsAsync(domainIdVO);
        await _validator.ValidateUniqueEmailForPersonAsync(personIdVO, userVO, domainIdVO);
        await _validator.ValidatePrimaryEmailAsync(personIdVO, primaryVO);

        var entity = PersonEmail.CreateNew(personIdVO, userVO, domainIdVO, primaryVO);
        await _repository.AddAsync(entity);
    }
}

