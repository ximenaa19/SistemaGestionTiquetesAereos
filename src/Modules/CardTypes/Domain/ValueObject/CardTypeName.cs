using System.Text.RegularExpressions;

namespace GestionAerolineas.src.Modules.CardTypes.Domain.ValueObject;

public sealed record CardTypeName
{
    public string Value { get; }

    private CardTypeName(string value)
    {
        Value = value;
    }

    public static CardTypeName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre no puede estar vacio");

        if (value.Length > 50)
            throw new ArgumentException("El nombre no puede superar 50 caracteres");

        var regex = new Regex("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$");

        if (!regex.IsMatch(value))
            throw new ArgumentException("El nombre solo puede contener letras y espacios");

        return new CardTypeName(value.Trim());
    }

    public override string ToString() => Value;
}
