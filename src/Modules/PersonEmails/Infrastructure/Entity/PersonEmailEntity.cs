namespace GestionAerolineas.src.Modules.PersonEmails.Infrastructure.Entity;

public class PersonEmailEntity
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string? User { get; set; }
    public int EmailDomainId { get; set; }
    public bool IsPrimary { get; set; }
}

