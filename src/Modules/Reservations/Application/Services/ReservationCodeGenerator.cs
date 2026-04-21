using System.Security.Cryptography;
using GestionAerolineas.src.Modules.Reservations.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Reservations.Application.Services;

public static class ReservationCodeGenerator
{
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public static ReservationCode Generate()
    {
        Span<byte> data = stackalloc byte[6];
        RandomNumberGenerator.Fill(data);

        var chars = new char[6];
        for (int i = 0; i < chars.Length; i++)
            chars[i] = Alphabet[data[i] % Alphabet.Length];

        return ReservationCode.Create(new string(chars));
    }
}

