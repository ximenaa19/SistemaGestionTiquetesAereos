using GestionAerolineas.src.Modules.Users.Domain.Repositories;
using GestionAerolineas.src.Modules.Users.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Users.Application.UseCases;

public class DeleteUserUseCase
{
    private readonly IUserRepository _repository;

    public DeleteUserUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(UserId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}
