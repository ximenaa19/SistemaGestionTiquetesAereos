namespace GestionAerolineas.src.Modules.Reservations.Domain.ValueObject
{
    public sealed record ReservationCustomerId
    {
        public int Value { get; }

        private ReservationCustomerId(int value)
        {
            Value = value;
        }

        public static ReservationCustomerId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El cliente_id no puede ser menor a 1");

            return new ReservationCustomerId(value);
        }
    }
}

