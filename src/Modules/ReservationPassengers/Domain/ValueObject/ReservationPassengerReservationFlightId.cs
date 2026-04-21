namespace GestionAerolineas.src.Modules.ReservationPassengers.Domain.ValueObject
{
    public sealed record ReservationPassengerReservationFlightId
    {
        public int Value { get; }

        private ReservationPassengerReservationFlightId(int value)
        {
            Value = value;
        }

        public static ReservationPassengerReservationFlightId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El reserva_vuelo_id no puede ser menor a 1");

            return new ReservationPassengerReservationFlightId(value);
        }
    }
}

