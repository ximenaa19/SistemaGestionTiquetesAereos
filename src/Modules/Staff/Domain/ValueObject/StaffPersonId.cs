namespace GestionAerolineas.src.Modules.Staff.Domain.ValueObject
{
    public sealed record StaffPersonId
    {
        public int Value { get; }

        private StaffPersonId(int value)
        {
            Value = value;
        }

        public static StaffPersonId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El persona_id no puede ser menor a 1");

            return new StaffPersonId(value);
        }
    }
}

