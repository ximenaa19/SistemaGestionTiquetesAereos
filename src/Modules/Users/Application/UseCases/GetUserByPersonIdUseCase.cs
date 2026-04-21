using GestionAerolineas.src.Modules.Users.Domain.Aggregate;
using GestionAerolineas.src.Modules.Users.Domain.Repositories;
using GestionAerolineas.src.Modules.Users.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Users.Application.UseCases;

public class GetUserByPersonIdUseCase
{
    private readonly IUserRepository _repository;

    public GetUserByPersonIdUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<User?> ExecuteAsync(int personId)
    {
        return _repository.GetByPersonIdAsync(UserPersonId.Create(personId));
    }
}
