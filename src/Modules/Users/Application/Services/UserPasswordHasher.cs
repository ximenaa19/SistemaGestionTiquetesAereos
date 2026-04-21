using BCrypt.Net;
using GestionAerolineas.src.Modules.Users.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Users.Application.Services;

public static class UserPasswordHasher
{
    public static UserPasswordHash Hash(string plainPassword)
    {
        if (string.IsNullOrWhiteSpace(plainPassword))
            throw new ArgumentException("La contraseña no puede estar vacia");

        var trimmed = plainPassword.Trim();

        if (trimmed.Length < 6)
            throw new ArgumentException("La contraseña debe tener al menos 6 caracteres");

        var hash = BCrypt.Net.BCrypt.HashPassword(trimmed);
        return UserPasswordHash.Create(hash);
    }
}
