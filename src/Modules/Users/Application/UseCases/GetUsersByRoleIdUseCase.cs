using GestionAerolineas.src.Modules.Users.Domain.Aggregate;
using GestionAerolineas.src.Modules.Users.Domain.Repositories;
using GestionAerolineas.src.Modules.Users.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Users.Application.UseCases;

public class GetUsersByRoleIdUseCase
{
    private readonly IUserRepository _repository;

    public GetUsersByRoleIdUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<User>> ExecuteAsync(int roleId)
    {
        return _repository.GetByRoleIdAsync(UserRoleId.Create(roleId));
    }
}
