using GestionAerolineas.src.Modules.Users.Application.Interfaces;
using GestionAerolineas.src.Modules.Users.Application.Services;
using GestionAerolineas.src.Modules.Users.Domain.Aggregate;
using GestionAerolineas.src.Modules.Users.Domain.Repositories;
using GestionAerolineas.src.Modules.Users.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Users.Application.UseCases;

public class UpdateUserUseCase
{
    private readonly IUserRepository _repository;
    private readonly IUserValidator _validator;

    public UpdateUserUseCase(IUserRepository repository, IUserValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(
        int id,
        string username,
        string? newPlainPassword,
        int? personId,
        int roleId,
        bool isActive,
        DateTime? lastAccess,
        string? actingUsername)
    {
        var idVO = UserId.Create(id);
        var existing = await _repository.GetByIdAsync(idVO);

        if (existing is null)
            throw new Exception("El user no existe");

        var usernameVO = UserUsername.Create(username);
        var personVO = UserPersonId.Create(personId);
        var roleVO = UserRoleId.Create(roleId);
        var isActiveVO = UserIsActive.Create(isActive);
        var lastAccessVO = UserLastAccess.Create(lastAccess);

        await _validator.ValidateUsernameAsync(usernameVO, idVO);
        await _validator.ValidatePersonExistsAsync(personVO);
        await _validator.ValidatePersonIsUniqueAsync(personVO, idVO);
        await _validator.ValidateRoleExistsAsync(roleVO);
        await _validator.ValidateCanDeactivateAsync(existing, isActiveVO, actingUsername);

        var passwordHashVO = string.IsNullOrWhiteSpace(newPlainPassword)
            ? existing.PasswordHash
            : UserPasswordHasher.Hash(newPlainPassword);

        var updated = User.Create(
            idVO,
            usernameVO,
            passwordHashVO,
            personVO,
            roleVO,
            isActiveVO,
            lastAccessVO,
            existing.CreatedAt,
            UserUpdatedAt.Create(DateTime.Now));

        await _repository.UpdateAsync(updated);
    }
}
