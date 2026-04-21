namespace GestionAerolineas.src.Modules.Staff.Domain.ValueObject
{
    public sealed record StaffRoleId
    {
        public int Value { get; }

        private StaffRoleId(int value)
        {
            Value = value;
        }

        public static StaffRoleId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El cargo_id no puede ser menor a 1");

            return new StaffRoleId(value);
        }
    }
}

