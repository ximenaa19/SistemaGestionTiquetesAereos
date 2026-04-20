namespace GestionAerolineas.src.Modules.Routes.Domain.ValueObject
{
    public sealed record RouteDistanceKm
    {
        public int? Value { get; }

        private RouteDistanceKm(int? value)
        {
            Value = value;
        }

        public static RouteDistanceKm Create(int? value)
        {
            if (!value.HasValue)
                return new RouteDistanceKm((int?)null);

            if (value.Value < 0)
                throw new ArgumentException("La distancia_km no puede ser negativa");

            return new RouteDistanceKm(value.Value);
        }
    }
}

