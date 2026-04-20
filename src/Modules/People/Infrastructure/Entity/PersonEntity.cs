namespace GestionAerolineas.src.Modules.People.Infrastructure.Entity;

public class PersonEntity
{
    public int Id { get; set; }
    public int DocumentTypeId { get; set; }
    public string? DocumentNumber { get; set; }
    public string? FirstNames { get; set; }
    public string? LastNames { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Gender { get; set; }
    public int? AddressId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

