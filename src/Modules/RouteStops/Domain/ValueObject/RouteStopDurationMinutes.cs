namespace GestionAerolineas.src.Modules.RouteStops.Domain.ValueObject
{
    public sealed record RouteStopDurationMinutes
    {
        public int Value { get; }

        private RouteStopDurationMinutes(int value)
        {
            Value = value;
        }

        public static RouteStopDurationMinutes Create(int value)
        {
            if (value < 0)
                throw new ArgumentException("La duracion_escala_min no puede ser negativa");

            return new RouteStopDurationMinutes(value);
        }
    }
}

