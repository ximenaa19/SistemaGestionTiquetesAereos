namespace GestionAerolineas.src.Modules.Staff.Domain.ValueObject
{
    public sealed record StaffId
    {
        public int Value { get; }

        private StaffId(int value)
        {
            Value = value;
        }

        public static StaffId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El id no puede ser menor a 1");

            return new StaffId(value);
        }

        public static StaffId CreateEmpty()
        {
            return new StaffId(0);
        }
    }
}

