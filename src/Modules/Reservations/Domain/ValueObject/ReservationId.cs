namespace GestionAerolineas.src.Modules.Reservations.Domain.ValueObject
{
    public sealed record ReservationId
    {
        public int Value { get; }

        private ReservationId(int value)
        {
            Value = value;
        }

        public static ReservationId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El id no puede ser menor a 1");

            return new ReservationId(value);
        }

        public static ReservationId CreateEmpty()
        {
            return new ReservationId(0);
        }
    }
}

