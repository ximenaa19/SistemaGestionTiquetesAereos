namespace GestionAerolineas.src.Modules.FlightSeats.Domain.ValueObject
{
    public sealed record FlightSeatCabinTypeId
    {
        public int Value { get; }

        private FlightSeatCabinTypeId(int value)
        {
            Value = value;
        }

        public static FlightSeatCabinTypeId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El tipo_cabina_id no puede ser menor a 1");

            return new FlightSeatCabinTypeId(value);
        }
    }
}

