namespace GestionAerolineas.src.Modules.Auth.Application.Models;

public sealed record AuthLoginResult(
    int UserId,
    string Username,
    int RoleId,
    bool IsActive
);

