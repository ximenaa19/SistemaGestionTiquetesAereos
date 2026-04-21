using GestionAerolineas.src.Modules.Users.Domain.Aggregate;
using GestionAerolineas.src.Modules.Users.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Users.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(UserId id);
    Task<User?> GetByUsernameAsync(UserUsername username);
    Task<User?> GetByPersonIdAsync(UserPersonId personId);
    Task<IEnumerable<User>> GetByRoleIdAsync(UserRoleId roleId);
    Task<IEnumerable<User>> GetByIsActiveAsync(UserIsActive isActive);
    Task<IEnumerable<User>> SearchByPersonNameAsync(string searchText);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task<bool> ExistsAsync(UserId id);
    Task<bool> ExistsByNormalizedUsernameAsync(string normalizedUsername, int? excludingId = null);
    Task<bool> ExistsByPersonIdAsync(int personId, int? excludingId = null);
}
