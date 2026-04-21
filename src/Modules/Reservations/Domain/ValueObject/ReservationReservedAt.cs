namespace GestionAerolineas.src.Modules.Reservations.Domain.ValueObject
{
    public sealed record ReservationReservedAt
    {
        public DateTime Value { get; }

        private ReservationReservedAt(DateTime value)
        {
            Value = value;
        }

        public static ReservationReservedAt Create(DateTime value)
        {
            return new ReservationReservedAt(value);
        }
    }
}

