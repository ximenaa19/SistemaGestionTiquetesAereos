using GestionAerolineas.src.Modules.Users.Domain.Aggregate;
using GestionAerolineas.src.Modules.Users.Domain.Repositories;
using GestionAerolineas.src.Modules.Users.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Users.Application.UseCases;

public class GetUserByUsernameUseCase
{
    private readonly IUserRepository _repository;

    public GetUserByUsernameUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<User?> ExecuteAsync(string username)
    {
        return _repository.GetByUsernameAsync(UserUsername.Create(username));
    }
}
