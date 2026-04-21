using GestionAerolineas.src.Modules.Users.Domain.Aggregate;
using GestionAerolineas.src.Modules.Users.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Users.Application.Interfaces;

public interface IUserValidator
{
    Task ValidateUsernameAsync(UserUsername username, UserId? currentId = null);
    Task ValidatePersonExistsAsync(UserPersonId personId);
    Task ValidatePersonIsUniqueAsync(UserPersonId personId, UserId? currentId = null);
    Task ValidateRoleExistsAsync(UserRoleId roleId);
    Task ValidateCanDeactivateAsync(User existingUser, UserIsActive newIsActive, string? actingUsername);
}
