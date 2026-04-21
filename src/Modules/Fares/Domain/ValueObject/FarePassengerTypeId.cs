namespace GestionAerolineas.src.Modules.Fares.Domain.ValueObject
{
    public sealed record FarePassengerTypeId
    {
        public int Value { get; }

        private FarePassengerTypeId(int value)
        {
            Value = value;
        }

        public static FarePassengerTypeId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El tipo_pasajero_id no puede ser menor a 1");

            return new FarePassengerTypeId(value);
        }
    }
}

