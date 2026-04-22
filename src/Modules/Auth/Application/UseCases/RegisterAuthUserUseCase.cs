using GestionAerolineas.src.Modules.Users.Application.UseCases;

namespace GestionAerolineas.src.Modules.Auth.Application.UseCases;

public class RegisterAuthUserUseCase
{
    private readonly CreateUserUseCase _createUserUseCase;

    public RegisterAuthUserUseCase(
        CreateUserUseCase createUserUseCase)
    {
        _createUserUseCase = createUserUseCase;
    }

    public async Task ExecuteAsync(string username, string plainPassword, int roleId)
    {
        await _createUserUseCase.ExecuteAsync(username, plainPassword, personId: null, roleId: roleId);
    }
}
