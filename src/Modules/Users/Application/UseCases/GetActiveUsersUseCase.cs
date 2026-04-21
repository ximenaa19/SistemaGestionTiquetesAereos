using GestionAerolineas.src.Modules.Users.Domain.Aggregate;
using GestionAerolineas.src.Modules.Users.Domain.Repositories;
using GestionAerolineas.src.Modules.Users.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Users.Application.UseCases;

public class GetActiveUsersUseCase
{
    private readonly IUserRepository _repository;

    public GetActiveUsersUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<User>> ExecuteAsync()
    {
        return _repository.GetByIsActiveAsync(UserIsActive.Create(true));
    }
}
