using GestionAerolineas.src.Modules.Users.Domain.Repositories;
using GestionAerolineas.src.Modules.Users.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Users.Application.UseCases;

public class DeleteUserHardUseCase
{
    private readonly IUserRepository _repository;

    public DeleteUserHardUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(UserId.Create(id));
        if (entity is null)
            throw new Exception("El user no existe");

        await _repository.DeleteAsync(entity);
    }
}
