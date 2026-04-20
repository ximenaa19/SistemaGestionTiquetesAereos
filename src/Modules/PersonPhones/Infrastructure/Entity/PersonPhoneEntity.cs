namespace GestionAerolineas.src.Modules.PersonPhones.Infrastructure.Entity;

public class PersonPhoneEntity
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int PhoneCodeId { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsPrimary { get; set; }
}

