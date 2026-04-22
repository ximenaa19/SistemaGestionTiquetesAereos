namespace GestionAerolineas.src.Modules.Checkins.Domain.ValueObject;

public record CheckinBaggageWeightKg(decimal Value)
{
    public static CheckinBaggageWeightKg Create(decimal? value)
    {
        var v = value ?? 0m;
        if (v < 0)
            throw new ArgumentException("peso_equipaje_kg no puede ser negativo");
        if (v > 999.99m)
            throw new ArgumentException("peso_equipaje_kg excede el maximo permitido (999.99)");
        return new CheckinBaggageWeightKg(decimal.Round(v, 2));
    }
}

