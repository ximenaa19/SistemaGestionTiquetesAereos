using GestionAerolineas.src.Modules.EmailDomains.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.EmailDomains.Application.Interfaces;

public interface IEmailDomainValidator
{
    Task ValidateDomainAsync(EmailDomainValue domain);
}

