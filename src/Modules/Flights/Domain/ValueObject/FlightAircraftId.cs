namespace GestionAerolineas.src.Modules.Flights.Domain.ValueObject
{
    public sealed record FlightAircraftId
    {
        public int Value { get; }

        private FlightAircraftId(int value)
        {
            Value = value;
        }

        public static FlightAircraftId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El aeronave_id no puede ser menor a 1");

            return new FlightAircraftId(value);
        }
    }
}

