namespace GestionAerolineas.src.Modules.ReservationPassengers.Domain.ValueObject
{
    public sealed record ReservationPassengerPassengerId
    {
        public int Value { get; }

        private ReservationPassengerPassengerId(int value)
        {
            Value = value;
        }

        public static ReservationPassengerPassengerId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El pasajero_id no puede ser menor a 1");

            return new ReservationPassengerPassengerId(value);
        }
    }
}

