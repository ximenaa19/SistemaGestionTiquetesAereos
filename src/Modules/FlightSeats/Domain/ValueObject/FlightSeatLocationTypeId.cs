namespace GestionAerolineas.src.Modules.FlightSeats.Domain.ValueObject
{
    public sealed record FlightSeatLocationTypeId
    {
        public int Value { get; }

        private FlightSeatLocationTypeId(int value)
        {
            Value = value;
        }

        public static FlightSeatLocationTypeId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El tipo_ubicacion_id no puede ser menor a 1");

            return new FlightSeatLocationTypeId(value);
        }
    }
}

