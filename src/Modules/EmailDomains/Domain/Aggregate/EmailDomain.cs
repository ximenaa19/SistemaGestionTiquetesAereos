using GestionAerolineas.src.Modules.EmailDomains.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.EmailDomains.Domain.Aggregate;

public class EmailDomain
{
    public EmailDomainId Id { get; private set; }
    public EmailDomainValue Domain { get; private set; }

    private EmailDomain(EmailDomainId id, EmailDomainValue domain)
    {
        Id = id;
        Domain = domain;
    }

    public static EmailDomain Create(EmailDomainId id, EmailDomainValue domain)
    {
        return new EmailDomain(id, domain);
    }

    public static EmailDomain CreateNew(EmailDomainValue domain)
    {
        return new EmailDomain(EmailDomainId.CreateEmpty(), domain);
    }
}

