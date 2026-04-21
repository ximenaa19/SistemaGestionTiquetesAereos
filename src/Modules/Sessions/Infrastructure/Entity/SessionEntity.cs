namespace GestionAerolineas.src.Modules.Sessions.Infrastructure.Entity;

public class SessionEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? EndedAt { get; set; }
    public string? IpAddress { get; set; }
    public bool IsActive { get; set; }
}
