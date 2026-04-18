namespace GestionAerolineas.src.Modules.Seasons.Domain.ValueObject;

public sealed record SeasonPriceFactor
{
    public decimal Value { get; }

    private SeasonPriceFactor(decimal value)
    {
        Value = value;
    }

    public static SeasonPriceFactor Create(decimal value)
    {
        if (value <= 0)
            throw new ArgumentException("El precio_factor debe ser mayor que 0");

        if (value > 9.9999m)
            throw new ArgumentException("El precio_factor no puede superar 9.9999");

        if (decimal.Round(value, 4) != value)
            throw new ArgumentException("El precio_factor no puede tener mas de 4 decimales");

        return new SeasonPriceFactor(value);
    }

    public override string ToString() => Value.ToString("0.0000");
}
