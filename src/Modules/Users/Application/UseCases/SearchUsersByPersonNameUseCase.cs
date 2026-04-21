using GestionAerolineas.src.Modules.Users.Domain.Aggregate;
using GestionAerolineas.src.Modules.Users.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Users.Application.UseCases;

public class SearchUsersByPersonNameUseCase
{
    private readonly IUserRepository _repository;

    public SearchUsersByPersonNameUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<User>> ExecuteAsync(string searchText)
    {
        return _repository.SearchByPersonNameAsync(searchText);
    }
}
