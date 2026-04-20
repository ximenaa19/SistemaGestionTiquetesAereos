namespace GestionAerolineas.src.Modules.Routes.Domain.ValueObject
{
    public sealed record RouteEstimatedDurationMinutes
    {
        public int? Value { get; }

        private RouteEstimatedDurationMinutes(int? value)
        {
            Value = value;
        }

        public static RouteEstimatedDurationMinutes Create(int? value)
        {
            if (!value.HasValue)
                return new RouteEstimatedDurationMinutes((int?)null);

            if (value.Value < 0)
                throw new ArgumentException("La duracion_estimada_min no puede ser negativa");

            return new RouteEstimatedDurationMinutes(value.Value);
        }
    }
}

