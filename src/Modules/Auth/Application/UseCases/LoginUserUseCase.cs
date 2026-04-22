using GestionAerolineas.src.Modules.Auth.Application.Models;
using GestionAerolineas.src.Modules.Sessions.Application.UseCases;
using GestionAerolineas.src.Modules.Users.Application.Services;
using GestionAerolineas.src.Modules.Users.Application.UseCases;
using GestionAerolineas.src.Modules.Users.Domain.Aggregate;
using GestionAerolineas.src.Modules.Users.Domain.Repositories;
using GestionAerolineas.src.Modules.Users.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Auth.Application.UseCases;

public class LoginUserUseCase
{
    private readonly GetUserByUsernameUseCase _getUserByUsernameUseCase;
    private readonly IUserRepository _userRepository;
    private readonly CreateSessionUseCase _createSessionUseCase;

    public LoginUserUseCase(
        GetUserByUsernameUseCase getUserByUsernameUseCase,
        IUserRepository userRepository,
        CreateSessionUseCase createSessionUseCase)
    {
        _getUserByUsernameUseCase = getUserByUsernameUseCase;
        _userRepository = userRepository;
        _createSessionUseCase = createSessionUseCase;
    }

    public async Task<AuthLoginResult> ExecuteAsync(string username, string plainPassword, string? ipAddress = null)
    {
        var user = await _getUserByUsernameUseCase.ExecuteAsync(username);
        if (user is null)
            throw new Exception("Usuario o contrasenia invalida");

        if (!user.IsActive.Value)
            throw new Exception("El usuario esta inactivo");

        var matches = UserPasswordHasher.Verify(plainPassword, user.PasswordHash);
        if (!matches)
            throw new Exception("Usuario o contrasenia invalida");

        await TouchLastAccessAsync(user);
        await _createSessionUseCase.ExecuteAsync(user.Id.Value, DateTime.Now, endedAt: null, ipAddress, isActive: true);

        return new AuthLoginResult(
            user.Id.Value,
            user.Username.Value,
            user.RoleId.Value,
            user.IsActive.Value);
    }

    private async Task TouchLastAccessAsync(User user)
    {
        var updated = User.Create(
            user.Id,
            user.Username,
            user.PasswordHash,
            user.PersonId,
            user.RoleId,
            user.IsActive,
            UserLastAccess.Create(DateTime.Now),
            user.CreatedAt,
            UserUpdatedAt.Create(DateTime.Now));

        await _userRepository.UpdateAsync(updated);
    }
}

