namespace GestionAerolineas.src.Modules.Reservations.Domain.ValueObject
{
    public sealed record ReservationStatusId
    {
        public int Value { get; }

        private ReservationStatusId(int value)
        {
            Value = value;
        }

        public static ReservationStatusId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El estado_reserva_id no puede ser menor a 1");

            return new ReservationStatusId(value);
        }
    }
}

