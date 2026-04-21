namespace GestionAerolineas.src.Modules.ReservationFlights.Domain.ValueObject
{
    public sealed record ReservationFlightReservationId
    {
        public int Value { get; }

        private ReservationFlightReservationId(int value)
        {
            Value = value;
        }

        public static ReservationFlightReservationId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El reserva_id no puede ser menor a 1");

            return new ReservationFlightReservationId(value);
        }
    }
}

